# Unity Polygon Mesh Sprite

## 简介

Unity推出的2d精灵图打包工具Sprite Packer和Sprite Atlas在使用过程中一直有一个最大的问题就是UGUI组件无法使用polygon mesh渲染精灵，只能使用rect方形渲染的方式。
这样就造成了使用tight剔除空白区域时，在运行环境下UI会把方形矩阵内所有的像素都渲染出来。

## 解决方法
1. Unity在2017版本只会实现了UI绘制polygon mesh的基础功能，那么就可以利用在sprite editor中自定义polygon outline来自定义一个Graphic组件或者自定义绘制顶点。

    _PolygonImage.cs_:
    ![](Sceneshots/Jietu20190416-143100.jpg)


2. Unity 2018.3版本之后在Image脚本内添加了`useSpriteMesh`的布尔值成员变量，即Unity官方终于在UI中绘制polygon mesh的功能啦！！！

## 参考
1. [Image.useSpriteMesh](https://docs.unity3d.com/ScriptReference/UI.Image-useSpriteMesh.html)
2. [Polygon mode sprites](http://qiankanglai.me/2016/03/05/polygon-sprites/index.html)
3. [UGUI 降低填充率技巧两则](https://blog.uwa4d.com/archives/fillrate.html)
4. [CiaccoDavide/Unity-UI-Polygon](https://github.com/CiaccoDavide/Unity-UI-Polygon/blob/master/UIPolygon.cs)