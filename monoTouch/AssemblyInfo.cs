using System;
using System.Reflection;
using MonoTouch.ObjCRuntime;

[assembly: AssemblyVersion("2.1.0")]
[assembly: LinkWith("libMCSwipeTableViewCell.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]