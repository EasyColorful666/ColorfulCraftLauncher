   M S B A M L   `   `   `  ���� P  LColorfulCraftLauncher, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ColorfulCraftLauncherColorfulCraftLauncher  &     ColorfulCraftLauncher.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     S OHandyControl, Version=3.5.1.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  :d2http://schemas.microsoft.com/expression/blend/2008  /local#clr-namespace:ColorfulCraftLauncher  -   $	��860��$	��504��  � Title$  ColorfulCraftLauncher�� � DataContext /   )ColorfulCraftLauncher.MainWindowViewModel  .��7  1HandyControl.Controls.TransitioningContentControl  .����    TabControlInLine#��[   �� TabStripPlacement$
 Left=�.@��� $��69��$��Center=�$��90������ .R���  �� Orientation$ 
Horizontal=�.+��� $��/Img/账户.png��$��24��$��24���� $��账户��$��5,0,0,0q�$��16(�.��� $	��770������  �� ImageSource$8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg��.+��� $��微软登录��$	��Top=�$��71��$	��350��$
��Left=�$��
385,93,0,0q����� *AuthenticateMicrosoftCommand+����  �� Mode$ OneWay=�  
ButtonInfo �� Source# [ �� $��外置登录��$��71��$	��350��$
��Left=�$��	385,0,0,0q����� *AuthenticateYggdrasilCommand+���� $ OneWay=�# [ �� $��离线登录��$	��Top=�$��71��$	��350��$
��Left=�$��385,314,0,0q����� *AuthenticateOfflineCommand+���� $ OneWay=�# [ �� -    ��Name$ listbox1��$��10,10,421,10q�
����������	#33333333���� *
Accounts+�� $��下载��$��90������ .R��� $ 
Horizontal=�.+��� $��/Img/下载.png��$��24��$��24���� $��下载��$��5,0,0,0q�$��16(�.���  J� RenderTransformOrigin$ 0.396,0.573&����� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg��.+��� .@��� $��游戏核心��.��� ���� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg��.+�9� -   	 9�Name$	 l1��$��所有版本��$��26,10,307,10q�.��� ���	#FFE5E5E5.+��� -   $	 lb1������ *
Versions+
 �� SelectedItem
 �� *SelectedVersion+-  'HandyControl.Controls.CircleProgressBar  -     Name$	 pb1��$��512,30,54,223q�  ProgressBarDangerCircle#��[ $	��200��$	��200�� � Value �� *ProgressValue+�� $��下载��$��487,338,0,0q�$	��Top=�$��86��$	��250��$
��Left=����� *InstallGameCoreCommand+���� $ OneWay=�# [ �� -    ��Name$ l2��$��Center=�$��Center=�$��9(�$��487,285,0,0q�$	��Top=�$	��250��$
��Left=����� *StatusMessage+�� $��Forge��.��� ���� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg���� $��Center=�$��28��$��Fabric��$��Center=�$��67��.��� ���� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg���� $��Center=�$��28��$��Optifine��$��Center=�$��67��.��� ���� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg���� $��Center=�$��28��$��NeoForge��$��Center=�$��86��.��� ���� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg���� $��Center=�$��28��$��Quilt��$��Center=�$��67��.��� ���� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg���� $��运行��$��90��$��69��$��Bottom=����� .R��� $ 
Horizontal=�.+��� $��/Img/运行.png��$��24��$��24���� $��运行��$��5,0,0,0q�$��16(�.��� ���� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg��.+� � $�� ��  � NavigationUIVisibility$ Hidden=��� -   $ listbox2��$
��Left=�$	��352��$��406,10,0,122q�$
��Auto=�$
��Auto=����� *LocalVersions+
 �� *SelectedLocalVersion+   HandyControl.Controls.Card  $��	0,0,375,0q����	#FF171515$��3,3,3,3q�.��� .+��� $��登录��$��	0,376,0,0q�$	��Top=�$��80��$	��270������ *SelectAccountCommand+�� $��Center=�$	��270��$��
0,10,0,117q����� *
Accounts+
 �� *SelectedAccount+ �� SelectedIndex �� *SelectedIndex+�� $��启动游戏��$��407,370,0,0q�$	��Top=�$��50��$	��271��$
��Left=����� *LaunchGameCommand+���� $ OneWay=�  ButtonSuccess# [ �� $��刷新列表��$��682,370,0,0q�$	��Top=�$��50��$��76��$
��Left=����� *RefreshGameListCommand+�� $��
安装Java��$��406,425,0,0q�$	��Top=�$��50��$	��271��$
��Left=����� *DownloadJavaCommand+���� $ OneWay=�# [ �� $��版本设置��$��682,425,0,0q�$	��Top=�$��50��$��76��$
��Left=��� $��模组��$��90������ .R��� $ 
Horizontal=�.+��� $��/Img/模组.png��$��24��$��24���� $��模组��$��5,0,0,0q�$��16(�.��� ���� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg�� � RowDefinitions �� �� $
��205* �.+�    EffectShadow2 J� Effect# �  $��68��$	��Top=�$��	10,8,10,0q�$��1��.��� $��90�� � ColumnDefinitions �� $	��25* ��� $	��96* �.+��� $��名称��$
��Left=�$��	31,17,0,0q�$	��Top=�%  HandyControl.Controls.SearchBar  $
��Left=� �� TextWrapping$
 Wrap=�$	��Top=�$��
108,17,0,0q�$��2��$	��619��   Command �� *SearchModsCommand+�� $��10,90,10,10q�$��1������ *ModVersions+�� $��90��$��0,0,0,1q����� .R��� $ 
Horizontal=�.+��� $��/Img/多人.png��$��24��$��24���� $��多人��$��5,0,0,0q�$��16(�.��� ���� $8 2/View/Windows/aaa7ffb2f2785400cd4007243b9a8cad.jpg��.+��� $��启动多人联机��$
��Left=�$��
11,356,0,0q�$	��Top=�$��78��$	��249���� $��10,10,10,175q����� *N2NLog+�� $��安装虚拟网卡��$��	0,356,0,0q�$	��Top=�$��78��$	��248��$ 0.495,1.148&����� *TapInstallCommand+�� $��停止多人联机��$
��Left=�$��509,356,0,0q�$	��Top=�$��78��$	��249���� $��设置��$��0,0,0,-1q�$��90������ .R��� $ 
Horizontal=�.+��� $��/Img/设置.png��$��24��$��24���� $��设置��$��5,0,0,0q�$��16(�.��� .+��� .@��� $��启动器设置��.��� ���	#FFE5E5E5�� $��游戏设置��.��� ���	#FFE5E5E5�� $��Center=�$��28��$��关于��$��Bottom=�$��67��.��� ���	#FFE5E5E5