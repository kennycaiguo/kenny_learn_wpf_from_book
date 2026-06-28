# 1.wpf中有多少种画刷

## 有SolidColorBursh，LinearGradientBrush，RadialGradientBrush，ImageBrush，VisualBrush和DrawingBrush

# 2.把一个VisualBrush定义为资源

```
 <Window.Resources>
     <VisualBrush x:Key="VisualBackgroud">
         <VisualBrush.Visual>
             <StackPanel Orientation="Horizontal">
                 <Image Source="/Images/bread1.png" Width="120" Height="50" />
                 <Image Source="/Images/coca.png" Width="120" Height="50" />
                 <Image Source="/Images/corn.png" Width="120" Height="50" />
                 <Image Source="/Images/mug.png" Width="120" Height="50" />
             </StackPanel>
         </VisualBrush.Visual> 
     </VisualBrush>
     
 </Window.Resources>
```

# 3.VisualBrush可以使用ContentTemplate吗

直接回答是：**不行**。`VisualBrush` 本身并没有 `ContentTemplate` 属性，且它的工作机制与基于数据模板的组件（如 `ContentControl`）不同。 [[1](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/painting-with-images-drawings-and-visuals), [2](https://www.cnblogs.com/dino623/p/ContentControl.html)]

`VisualBrush` 的核心作用是**将一个现有的可视元素（Visual）作为画刷**进行绘制。因此，它的内容是通过 `Visual` 属性直接指定具体的 UI 元素或控件实例。 [[1](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visualbrush.visual?view=windowsdesktop-10.0), [2](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visualbrush?view=windowsdesktop-10.0), [3](https://www.c-sharpcorner.com/UploadFile/raj1979/visual-brush-in-wpf/)]

如果您想在 `VisualBrush` 中实现类似于 `ContentTemplate`（即通过数据或模板动态生成内容）的效果，可以参考以下**两种替代方案**：

方案一：在外层嵌套 `ContentControl`

利用 `ContentControl` 的 `ContentTemplate` 功能来承载数据模板，并将该 `ContentControl` 直接赋值给 `VisualBrush.Visual` 属性。

**XAML 实现示例：**

xml

```
<Window.Resources>
    <!-- 定义 DataTemplate -->
    <DataTemplate x:Key="MyTemplate">
        <StackPanel Orientation="Horizontal">
            <Ellipse Fill="Red" Width="10" Height="10" Margin="5"/>
            <TextBlock Text="{Binding}" Foreground="Blue"/>
        </StackPanel>
    </DataTemplate>
    
    <!-- 使用 ContentControl 结合 DataTemplate，并作为 VisualBrush 的 Visual -->
    <VisualBrush x:Key="MyVisualBrush">
        <VisualBrush.Visual>
            <ContentControl Content="动态文本内容" ContentTemplate="{StaticResource MyTemplate}"/>
        </VisualBrush.Visual>
    </VisualBrush>
</Window.Resources>
```

 

方案二：使用 `ControlTemplate` 手动包装

如果您的目的是为了自定义 `Visual` 元素的外观，可以通过给 `Visual` 赋予一个应用了 `ControlTemplate` 的控件（如 `ContentControl`）来实现。

**XAML 实现示例：**

xml

```
<VisualBrush x:Key="MyCustomBrush">
    <VisualBrush.Visual>
        <ContentControl>
            <ContentControl.Template>
                <ControlTemplate>
                    <Grid>
                        <Rectangle Fill="LightGray" />
                        <!-- 这里可以自定义视觉树 -->
                        <ContentPresenter Content="自定义包装内容" Margin="10"/>
                    </Grid>
                </ControlTemplate>
            </ContentControl.Template>
        </ContentControl>
    </VisualBrush.Visual>
</VisualBrush>
```

# 4.把StackPanel定义为资源，然后给VisualBrush使用

```
...
 <Window.Resources>

     <StackPanel x:Key="VisualBackgroud" Orientation="Horizontal">
         <Image Source="/Images/bread1.png" Width="120" Height="50" />
         <Image Source="/Images/coca.png" Width="120" Height="50" />
         <Image Source="/Images/corn.png" Width="120" Height="50" />
         <Image Source="/Images/mug.png" Width="120" Height="50" />
     </StackPanel>
     
 </Window.Resources>
 ...
   <DockPanel>
     <Rectangle Margin="5">
         <Rectangle.Fill>
             <VisualBrush Visual="{StaticResource VisualBackgroud}" 
                          TileMode="Tile" 
                          Viewport="0,0,.5,.1" />
         </Rectangle.Fill>
         
     </Rectangle>
 </DockPanel>
     
     ...
```

![image-20260627154513212](./wpf知识点.assets/image-20260627154513212.png)

# 5.visualbrush可以使用contenttemplate吗

**VisualBrush** 本身没有 `ContentTemplate` 属性。它使用的是 `Visual` 属性来承载内容。如果您想通过模板来动态生成或定义画刷的显示内容，有以下几种实现方式： [[1](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.visualbrush.visual?view=windowsdesktop-10.0)]

1. 使用 DataTemplate（配合 ContentPresenter）

您可以将包含 `DataTemplate` 的 `ContentPresenter` 赋值给 `VisualBrush.Visual`。这允许您通过模板化内容来渲染画刷。

xml

```
<VisualBrush>
    <VisualBrush.Visual>
        <ContentPresenter Content="数据对象">
            <ContentPresenter.ContentTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding}" Foreground="Blue"/>
                </DataTemplate>
            </ContentPresenter.ContentTemplate>
        </ContentPresenter>
    </VisualBrush.Visual>
</VisualBrush>
```

 

2. 在 XAML 资源中直接定义 Visual

通常情况下，您不需要使用模板，可以直接在 `VisualBrush.Visual` 中使用 XAML 布局或控件作为呈现内容。 [[1](https://www.c-sharpcorner.com/UploadFile/raj1979/visual-brush-in-wpf/)]

xml

```
<Rectangle>
    <Rectangle.Fill>
        <VisualBrush>
            <VisualBrush.Visual>
                <StackPanel Orientation="Horizontal" Background="White">
                    <TextBlock Text="WPF" />
                    <Button Content="按钮" />
                </StackPanel>
            </VisualBrush.Visual>
        </VisualBrush>
    </Rectangle.Fill>
</Rectangle>
```

 

3. 使用 ControlTemplate（针对无视觉树对象）

如果您的目标对象是一个没有原生视觉呈现的类，可以将其放置在支持模板的控件（如 `ContentControl`）中，再将该控件设为 `VisualBrush` 的 `Visual`。

```
<Window.Resources>
    <!-- 1. 定义 DataTemplate 内容模板 -->
    <DataTemplate x:Key="MyContentTemplate">
        <Border BorderBrush="Blue" Background="AliceBlue" Padding="5">
            <TextBlock Text="{Binding}" />
        </Border>
    </DataTemplate>

    <!-- 2. 在 ControlTemplate 中配置 VisualBrush -->
    <ControlTemplate x:Key="MyControlTemplate" TargetType="ContentControl">
        <Grid>
            <Grid.Background>
                <!-- Visual 指向下面的 ContentPresenter -->
                <VisualBrush Visual="{Binding ElementName=myPresenter}" Opacity="0.5" />
            </Grid.Background>
            <ContentPresenter x:Name="myPresenter" 
                              Content="{TemplateBinding Content}" 
                              ContentTemplate="{StaticResource MyContentTemplate}"/>
        </Grid>
    </ControlTemplate>
</Window.Resources>

<!-- 3. 应用样式 -->
<ContentControl Template="{StaticResource MyControlTemplate}"
                Content="示例内容" Width="200" Height="100" />

```

