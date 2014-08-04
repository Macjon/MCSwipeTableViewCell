XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT_ROOT=xCode/MCSwipe-Demo
PROJECT=$(PROJECT_ROOT)/MCSwipe-Demo.xcodeproj
TARGET=MCSwipeTableViewCell

all: MCSwipeTableViewCell.dll

libMCSwipeTableViewCell-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libMCSwipeTableViewCell-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libMCSwipeTableViewCell.a: libMCSwipeTableViewCell-i386.a libMCSwipeTableViewCell-armv7.a
	lipo -create -output $@ $^

MCSwipeTableViewCell.dll: monoTouch/ApiDefinition.cs monoTouch/enums.cs monoTouch/AssemblyInfo.cs libMCSwipeTableViewCell.a
	$(BTOUCH) monoTouch/ApiDefinition.cs monoTouch/enums.cs monoTouch/AssemblyInfo.cs --out=$@ --link-with=libMCSwipeTableViewCell.a,libMCSwipeTableViewCell.a

clean: 
	-rm -f *.a *.dll