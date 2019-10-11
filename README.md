# uMap
Simple WPF MVVM application to display a world map using Open Street Map provider

App appearance:


<img src="https://habrastorage.org/webt/vz/ey/oy/vzeyoyt5qho5yovxhjm0dfyqe9o.png" />

Application use DevExpress control called MapControl, for using you sghould install or download required libraries (version of DevExpress 18 or above):

* DevExpress.Data.v18.1
* DevExpress.Images.v18.1
* DevExpress.Map.v18.1.Core
* DevExpress.Mvvm.v18.1
* DevExpress.Office.v18.1.Core
* DevExpress.Pdf.v18.1.Core
* DevExpress.Printing.v18.1.Core
* DevExpress.RichEdit.v18.1.Core
* DevExpress.Xpf.Core.v18.1
* DevExpress.Xpf.Docking.v18.1
* DevExpress.Xpf.DocumentViewer.v18.1.Core
* DevExpress.Xpf.Grid.v18.1
* DevExpress.Xpf.Grid.v18.1.Core
* DevExpress.Xpf.Layout.v18.1.Core
* DevExpress.Xpf.LayoutControl.v18.1
* DevExpress.Xpf.Map.v18.1
* DevExpress.Xpf.Printing.v18.1
* DevExpress.Xpf.Ribbon.v18.1
* DevExpress.Xpf.Themes.Office2016White.v18.1

## For darcula or metro themes I used WPFToolkit and WPFToolkit.DataVisualization (JenniLe, Shimmy)

To change themes manualy you should comment old and uncomment required theme in App.xaml
f.e Metro Dark Theme:

''' xml

<ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- IG Theme -->
                <!-- <ResourceDictionary Source="Themes/IG/IG.MSControls.Core.Implicit.xaml" /> -->
                <!-- <ResourceDictionary Source="Themes/IG/IG.MSControls.Toolkit.Implicit.xaml" /> -->

                <!-- Metro Theme -->
                <!--<ResourceDictionary Source="Themes/Metro/Metro.MSControls.Core.Implicit.xaml" />
                <ResourceDictionary Source="Themes/Metro/Metro.MSControls.Toolkit.Implicit.xaml" /> -->

                <!-- MetroDark Theme -->
                <ResourceDictionary Source="Themes/MetroDark/MetroDark.MSControls.Core.Implicit.xaml" />
                <ResourceDictionary Source="Themes/MetroDark/MetroDark.MSControls.Toolkit.Implicit.xaml" /> 

            </ResourceDictionary.MergedDictionaries>

            <!-- <SolidColorBrush x:Key="BackgroundKey" Color="#FFFFFF" /> Color="#FF181818" -->

            <!-- Dark Theme -->
            <SolidColorBrush x:Key="BackgroundKey" Color="#000000" />

            <Style x:Key="HeaderTextBlockStyle" TargetType="TextBlock">
                <Setter Property="FontSize" Value="22" />
                <Setter Property="FontFamily" Value="Segoe UI" />
                <Setter Property="Foreground" Value="#FF00AADE" />
            </Style>

            <Style x:Key="SubHeaderTextBlockStyle" TargetType="TextBlock">
                <Setter Property="FontSize" Value="18" />
                <Setter Property="FontFamily" Value="Segoe UI" />
                <Setter Property="Foreground" Value="#FF00AADE" />
            </Style>

        </ResourceDictionary>
    </Application.Resources>
'''

