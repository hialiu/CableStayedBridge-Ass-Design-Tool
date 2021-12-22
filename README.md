# 斜拉桥辅助设计工具v1.0

同济大学数据库技术课程作业，成员：杨一，陈南西，崔银健。

## 简介
这是一个用于**斜拉桥辅助设计**的工具，对于初次接触斜拉桥设计的用户也很友好，主要可以实现以下功能：
> 1. 通过内置匹配算法得到与用户初拟参数较为匹配的工程实例，便于用户参照已有工程进行设计。
> 2. 用户可对工程实例进行评论，实现不同用户间的相互交流。
> 3. 用户在模型设计界面简单填入参数即可在界面实时显示斜拉桥立面布置图，用户可反复更改以获得满意的模型。
> 4. 用户在模型界面可以管理之前的设计模型。


## 如何开始
### 起始页
* 点击 **“*Start*”** 按钮即可进入登录界面；

* 点击 **“*Exit*”** 按钮可以退出程序；

* 点击 **“*Help*”** 按钮可以打开帮助文档链接。

<br/>


<center>

<img width=500 src="pic/start.png" />

</center>

<center>

图 1 起始页

</center>

<br/>
    
### 登录界面
* 普通用户输入用户名和密码点击 **“*登录* ”** 按钮即可登录；

* 若没有账号，可以点击 **“*注册* ”** 创建账号;

* 管理员可点击 **“*管理员模式* ”** 进入后台管理员界面。

<br/>

<center>

<img width=400 src="pic/sign_in1.png" />

</center>

<center>

图 2 登录界面

</center>

<br/>

### 注册界面
* 用户在 **注册界面** 可以创建一个新账号，密码需不少于8位；

* 用户在创建过程中若有不恰当操作，程序将会作出提示；

* 用户注册完之后可在 **登录界面** 登录账号。


<br>

<center>

<img width=500 src="pic/sign_up.png" />

</center>

<center>

图 3 注册界面

</center>

<br>



## 主界面
用户登录之后可以进入 **主界面** ，主界面包括以下三个功能：

*  **注册界面** 
*  **模型设计**
*  **模型管理**

用户可以点击对应图标进入相应界面。

<br>

<center>

<img width=500 src="pic/main.png" />

</center>

<center>

图 4 主界面

</center>

<br>


### 案例参考
在案例参考界面，用户可以通过输入 **跨径布置** 和 **桥塔高度** 进行匹配查询，程序会匹配出数据库中与用户输入参数最相似的几个工程案例供用户参考，用户可在 **“*匹配结果* ”** 中下拉查看工程案例的具体信息；

当鼠标移动到可以操作的控件时，会有对应的 **提示信息** ，例如:
* 在 **跨径布置** 文本框会出现：“输入跨径布置，用“+”隔开，形如“100+200+100””
* 在 **桥塔高度** 文本框会出现：“输入上塔柱高度，输入完按enter，程序将自动查询与模型信息匹配的案例资料”


用户可以点击 **“*加载评论* ”** 按钮以加载该工程案例的最新评论情况；

用户可以在 **添加评论** 区域输入自己的评论，添加后可以点击 **“*加载评论* ”** 按钮即可查看刚添加的评论。

<br>

<!--图片怎么居中

<img src="pic/bridge_example_comment1.png" width = "300" height = "200" alt="bridge_example" align="center"/>

<div align="center"><img src="pic/bridge_example_comment1.png" /></div>

-->

<center>

<img width=700 src="pic/bridge_example_comment1.png" />

</center>

<center>

图 5 案例参考界面

</center>

<br>

<center>

<img width=700 src="pic/bridge_example_comment2.png" />

</center>

<center>

图 6 案例参考界面-成功添加评论

</center>

<br>


### 模型设计
用户可以在模型设计界面进行 **主梁和桥塔选型** ，输入相应设计参数后程序可以自动绘制出相应的 **立面图** 。其中跨径布置、桥塔高度、梁上索距，塔上索距是必填参数，*拉索起始位置是可选参数*，若不填，程序默认为2/3。

当用户鼠标移至相应文本框时，会弹出相应的参数填写的 **提示信息** ，例如：
* **跨径布置** 文本框："输入跨径布置，用“+”隔开，形如“100+200+100”"
* **桥塔高度** 文本框："输入桥塔高度，可以只指定上塔柱高度，形如“70”，也可以指定下塔柱与上塔柱高度，形如“20+70”"
* **梁上索距** 文本框："输入梁上索距，用一个数字表示，一般砼主梁为6-12，钢主梁为8-16"
* **塔上索距** 文本框："输入塔上索距，用一个数字表示，一般为2~2.5"
* **索起始位置** 文本框："可选参数，可输入1号索在塔上的起始位置，如“3/4”表示在1号索在上塔柱3/4位置"

同样，当用户鼠标移至相应按钮时，也会弹出提示信息。





<br>

<center>

<img width=600 src="pic/model_design1.png" />

</center>

<center>

图 7 模型设计界面

</center>

<br>

立面图绘制功能采用 ***python*** 程序实现，用户点击 **“*保存立面按钮* ”** 可以将立面图保存为 ***svg*** 格式，之后用户可以根据实际需要将 ***svg*** 文件转换为 ***dwg*** 文件。

<br>

<center>

<img width=600 src="pic/model_design2.png" />

</center>

<center>

图 8 模型设计界面-保存立面图

</center>

<br>

点击 **“*上传模型* ”** 按钮可将当前模型参数上传至云端数据库进行保存。

<br>

<center>

<img width=600 src="pic/model_design3.png" />

</center>

<center>

图 8 模型设计界面-上传模型

</center>

<br>

### 模型管理
在**模型管理**界面，用户可以查看自己上传至云端数据库的模型，也可以删除之前保存的模型，点击 **“*导出参数* ”** 按钮还能将模型参数信息以txt文本格式导出。

<br>

<center>

<img width=600 src="pic/model_check1.png" />

</center>

<center>

图 9 模型管理界面

</center>

<br>

<center>

<img width=600 src="pic/model_check2.png" />

</center>

<center>

图 10 模型管理界面-导出参数

</center>

<br>



## 管理员模式
**管理员模式**是专门为管理员提供的，管理员需要在管理员验证界面（在 **登录界面** 跳转）输入 **管理员名称** 和 **管理员密钥**，才能进入 **后台管理系统** 。

<br>

<center>

<img width=400 src="pic/admin_pass.png" />
</center>

<center>
图 11 管理员验证界面

</center>

<br>

管理员身份验证成功后，即可进入 **后台管理员界面** 。在此界面，管理员可以更新已有案例信息、删除已有案例、新建工程案例。如果要更新图片的话，点击图片区域会弹出选择图片的对话框，选中相应文件即可添加或更换图片。

<br>

<center>

<img width=600 src="pic/admin.png" />

</center>

<center>

图 12 后台管理员界面

</center>

<br>


