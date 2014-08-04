/*
    Copyright (c) 2014 Ali Karagoz (http://alikaragoz.net/)

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
using System.Drawing;
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace MonoTouch.MCSwipeTableViewCell
{
    delegate void MCSwipeCompletionBlock(MCSwipeTableViewCell cell,MCSwipeTableViewCellState state,MCSwipeTableViewCellMode mode);
    delegate void SwipeCompletion();

    [Protocol, Model, BaseType(typeof(NSObject))]
    interface MCSwipeTableViewCellDelegate
    {

        [Export("swipeTableViewCellDidStartSwiping:")]
        void DidStartSwiping(MCSwipeTableViewCell cell);

        [Export("swipeTableViewCellDidEndSwiping:")]
        void DidEndSwiping(MCSwipeTableViewCell cell);

        [Export("swipeTableViewCell:didSwipeWithPercentage:")]
        void DidSwipeWithPercentage(MCSwipeTableViewCell cell, float percentage);
    }

    [BaseType(typeof(UITableViewCell))]
    interface MCSwipeTableViewCell
    {

        [Export("delegate", ArgumentSemantic.Assign)]
        MCSwipeTableViewCellDelegate Delegate { get; set; }

        [Export("damping")]
        float Damping { get; set; }

        [Export("velocity")]
        float Velocity { get; set; }

        [Export("animationDuration")]
        double AnimationDuration { get; set; }

        [Export("defaultColor", ArgumentSemantic.Retain)]
        UIColor DefaultColor { get; set; }

        [Export("color1", ArgumentSemantic.Retain)]
        UIColor Color1 { get; set; }

        [Export("color2", ArgumentSemantic.Retain)]
        UIColor Color2 { get; set; }

        [Export("color3", ArgumentSemantic.Retain)]
        UIColor Color3 { get; set; }

        [Export("color4", ArgumentSemantic.Retain)]
        UIColor Color4 { get; set; }

        [Export("view1", ArgumentSemantic.Retain)]
        UIView View1 { get; set; }

        [Export("view2", ArgumentSemantic.Retain)]
        UIView View2 { get; set; }

        [Export("view3", ArgumentSemantic.Retain)]
        UIView View3 { get; set; }

        [Export("view4", ArgumentSemantic.Retain)]
        UIView View4 { get; set; }

        [Export("completionBlock1", ArgumentSemantic.Copy)]
        MCSwipeCompletionBlock CompletionBlock1 { get; set; }

        [Export("completionBlock2", ArgumentSemantic.Copy)]
        MCSwipeCompletionBlock CompletionBlock2 { get; set; }

        [Export("completionBlock3", ArgumentSemantic.Copy)]
        MCSwipeCompletionBlock CompletionBlock3 { get; set; }

        [Export("completionBlock4", ArgumentSemantic.Copy)]
        MCSwipeCompletionBlock CompletionBlock4 { get; set; }

        [Export("firstTrigger")]
        float FirstTrigger { get; set; }

        [Export("secondTrigger")]
        float SecondTrigger { get; set; }

        [Export("modeForState1")]
        MCSwipeTableViewCellMode ModeForState1 { get; set; }

        [Export("modeForState2")]
        MCSwipeTableViewCellMode ModeForState2 { get; set; }

        [Export("modeForState3")]
        MCSwipeTableViewCellMode ModeForState3 { get; set; }

        [Export("modeForState4")]
        MCSwipeTableViewCellMode ModeForState4 { get; set; }

        [Export("dragging")]
        bool Dragging { [Bind ("isDragging")] get; }

        [Export("shouldDrag")]
        bool ShouldDrag { get; set; }

        [Export("shouldAnimateIcons")]
        bool ShouldAnimateIcons { get; set; }

        [Export("setSwipeGestureWithView:color:mode:state:completionBlock:")]
        void SetSwipeGestureWithView(UIView view, UIColor color, MCSwipeTableViewCellMode mode, MCSwipeTableViewCellState state, MCSwipeCompletionBlock completionBlock);

        [Export("swipeToOriginWithCompletion:")]
        void SwipeToOriginWithCompletion(SwipeCompletion completion);

        [Export("withoutSwipingBackToOrigin")]
        bool WithoutSwipingBackToOrigin { get; set; }

        [Export("hideContentViewOnDrag")]
        bool HideContentViewOnDrag { get; set; }

        [Export("makeViewTransparentOnSwipe")]
        bool MakeViewTransparentOnSwipe { get; set; }
    }
}
