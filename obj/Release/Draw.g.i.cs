﻿#pragma checksum "C:\Users\Sherry\Documents\Visual Studio 2013\Projects\Stickies\Stickies\Draw.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "38C9700B0FF15CA98CD8D2A5319025E8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Stickies {
    
    
    public partial class Draw : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.Canvas canvas1;
        
        internal System.Windows.Controls.Image dustbin;
        
        internal System.Windows.Controls.ScrollViewer callOutFigures;
        
        internal System.Windows.Controls.StackPanel callOutFiguresStack;
        
        internal System.Windows.Controls.Image figure1;
        
        internal System.Windows.Controls.Image figure11;
        
        internal System.Windows.Controls.Image figure12;
        
        internal System.Windows.Controls.Image figure2;
        
        internal System.Windows.Controls.Image figure3;
        
        internal System.Windows.Controls.Image figure4;
        
        internal System.Windows.Controls.Image figure5;
        
        internal System.Windows.Controls.Image figure6;
        
        internal System.Windows.Controls.Image figure7;
        
        internal System.Windows.Controls.Image figure8;
        
        internal System.Windows.Controls.Image figure9;
        
        internal System.Windows.Controls.Image figure10;
        
        internal System.Windows.Controls.Image figure18;
        
        internal System.Windows.Controls.Image figure13;
        
        internal System.Windows.Controls.Image figure14;
        
        internal System.Windows.Controls.Image figure15;
        
        internal System.Windows.Controls.Image figure16;
        
        internal System.Windows.Controls.Image figure17;
        
        internal System.Windows.Controls.Image figure19;
        
        internal System.Windows.Controls.Image figure20;
        
        internal System.Windows.Controls.Image figure21;
        
        internal System.Windows.Controls.Image figure22;
        
        internal System.Windows.Controls.Image figure23;
        
        internal System.Windows.Controls.Image figure24;
        
        internal System.Windows.Controls.ScrollViewer stickieCallouts;
        
        internal System.Windows.Controls.StackPanel callOutImagesStack;
        
        internal System.Windows.Controls.Image callOutText;
        
        internal System.Windows.Controls.Image callOutConnector;
        
        internal System.Windows.Controls.Image calloutCancelAll;
        
        internal System.Windows.Controls.Button btnSave;
        
        internal System.Windows.Controls.Button btnCancel;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Stickies;component/Draw.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.canvas1 = ((System.Windows.Controls.Canvas)(this.FindName("canvas1")));
            this.dustbin = ((System.Windows.Controls.Image)(this.FindName("dustbin")));
            this.callOutFigures = ((System.Windows.Controls.ScrollViewer)(this.FindName("callOutFigures")));
            this.callOutFiguresStack = ((System.Windows.Controls.StackPanel)(this.FindName("callOutFiguresStack")));
            this.figure1 = ((System.Windows.Controls.Image)(this.FindName("figure1")));
            this.figure11 = ((System.Windows.Controls.Image)(this.FindName("figure11")));
            this.figure12 = ((System.Windows.Controls.Image)(this.FindName("figure12")));
            this.figure2 = ((System.Windows.Controls.Image)(this.FindName("figure2")));
            this.figure3 = ((System.Windows.Controls.Image)(this.FindName("figure3")));
            this.figure4 = ((System.Windows.Controls.Image)(this.FindName("figure4")));
            this.figure5 = ((System.Windows.Controls.Image)(this.FindName("figure5")));
            this.figure6 = ((System.Windows.Controls.Image)(this.FindName("figure6")));
            this.figure7 = ((System.Windows.Controls.Image)(this.FindName("figure7")));
            this.figure8 = ((System.Windows.Controls.Image)(this.FindName("figure8")));
            this.figure9 = ((System.Windows.Controls.Image)(this.FindName("figure9")));
            this.figure10 = ((System.Windows.Controls.Image)(this.FindName("figure10")));
            this.figure18 = ((System.Windows.Controls.Image)(this.FindName("figure18")));
            this.figure13 = ((System.Windows.Controls.Image)(this.FindName("figure13")));
            this.figure14 = ((System.Windows.Controls.Image)(this.FindName("figure14")));
            this.figure15 = ((System.Windows.Controls.Image)(this.FindName("figure15")));
            this.figure16 = ((System.Windows.Controls.Image)(this.FindName("figure16")));
            this.figure17 = ((System.Windows.Controls.Image)(this.FindName("figure17")));
            this.figure19 = ((System.Windows.Controls.Image)(this.FindName("figure19")));
            this.figure20 = ((System.Windows.Controls.Image)(this.FindName("figure20")));
            this.figure21 = ((System.Windows.Controls.Image)(this.FindName("figure21")));
            this.figure22 = ((System.Windows.Controls.Image)(this.FindName("figure22")));
            this.figure23 = ((System.Windows.Controls.Image)(this.FindName("figure23")));
            this.figure24 = ((System.Windows.Controls.Image)(this.FindName("figure24")));
            this.stickieCallouts = ((System.Windows.Controls.ScrollViewer)(this.FindName("stickieCallouts")));
            this.callOutImagesStack = ((System.Windows.Controls.StackPanel)(this.FindName("callOutImagesStack")));
            this.callOutText = ((System.Windows.Controls.Image)(this.FindName("callOutText")));
            this.callOutConnector = ((System.Windows.Controls.Image)(this.FindName("callOutConnector")));
            this.calloutCancelAll = ((System.Windows.Controls.Image)(this.FindName("calloutCancelAll")));
            this.btnSave = ((System.Windows.Controls.Button)(this.FindName("btnSave")));
            this.btnCancel = ((System.Windows.Controls.Button)(this.FindName("btnCancel")));
        }
    }
}

