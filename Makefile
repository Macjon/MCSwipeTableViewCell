XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
BTOUCH=/Developer/MonoTouch/usr/bin/btouch
PROJECT_ROOT=xCode
PROJECT=$(PROJECT_ROOT)/MCSwipe Demo/MCSwipe Demo.xcodeproj
TARGET=MCSwipeTableViewCell

all: libMCSwipeTableViewCell.a

libMCSwipeTableViewCell-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libMCSwipeTableViewCell-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libMCSwipeTableViewCell.a: libMCSwipeTableViewCell-i386.a libMCSwipeTableViewCell-armv7.a
	lipo -create -output $@ $^

#MDHTMLLabel.dll: ApiDefinition.cs enums.cs AssemblyInfo.cs libMDHTMLLabel.a
#	$(BTOUCH) ApiDefinition.cs enums.cs AssemblyInfo.cs --out=$@ --link-with=libMDHTMLLabel.a,libMDHTMLLabel.a

clean: 
	-rm -f *.a *.dll