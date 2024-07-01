# RTSP Patrina 很萌录制器

RTSP Patrina is a tool for lossless capture of IPTV multimedia data streams over the RTSP protocol and MPEG2-TS encapsulation format. Especially useful for IPTV recording from Asian ISPs such as China PR and South Korea.

很萌录制器是一款适用于无损采集基于RTSP协议、MPEG2-TS封装格式的IPTV多媒体数据流的软件。


![RTSP Patrina preview](https://thumbs2.imgbox.com/2a/c9/pPpIlHlh_t.png)


# Software features / 软件功能

- Supports configuration templates to customize RTSP request bodies. Supports setting variables.

- Multi-task management.

- Supports lossless capture of MPEG2-TS packets using TCP and UDP clients. Supports automatic removal of RTP headers.

- English language support.

---

- 支持配置模板自定义RTSP请求正文。支持设置变量。

- 支持批量任务管理。

- 支持TCP、UDP客户端无损采集MPEG2-TS数据包。支持自动去除RTP头。

- 简体中文语言支持。


# System requirements / 系统要求 

Applicable for Windows 7 and above operating systems.

适用于Windows 7及以上操作系统。


# Changelog / 更新日志

**5.3.0 (2022/08/06)**

1.支持默认不启动UDP客户端。仅当配置文件中的请求报文存在"[UDP]"字样时，再自动启动UDP客户端。

2.修复了自动启动UDP客户端的情况下，当任务停止后，端口无法复用的问题。

---

**5.2.2 (2022/01/01)**

1.优化TCP连接缓存处理机制。

2.优化UDP连接缓存参数。

---

**5.2.0 (2021/12/29)**

1.批量任务面板中已启动的任务可通过右键单击切换至未启动状态。

2.任务启动时若文件名已存在，则自动重命名，而不覆盖旧文件。

3.调整控制台窗口默认大小。

---

**5.1.0 (2021/11/22)**

1.新增视频快速预览功能，可双击图标调用本地播放器播放正在录制中的视频。

2.新增视频信息快速检索功能，可双击图标显示正在录制的视频的基本信息。该功能依赖FFmpeg组件。在录制模块空闲时将打开控制台。

3.增强单击任务名称打开工作目录时的路径识别能力。

4.使用UDP协议传输并录制媒体流时，将主动发送用于NAPT穿透的RTCP报文，使部分NAPT场景下接收UDP媒体流时无需配置服务器映射。

5.使用UDP协议传输并录制媒体流时，优化随机生成的UDP多媒体有效荷载接收端口号为总是偶数。

6.更完善的简体中文界面支持。

7.部分代码细节优化。

---

**5.0.10 (2021/02/26)**

1.解决了使用UDP协议传输并录制媒体流时，随机生成的UDP接收端口可能已经被操作系统占用从而导致录制失败的问题。UDP接收程序将自动检测并避开已被占用的端口号。

2.解决了使用UDP协议传输并录制媒体流时，因不明套接字空口冲突原因，导致概率性无法启动录制或录制中断的问题。该问题当前未能完全定位，在一些特殊网络场景下可能复现。

3.解决了使用UDP协议传输并录制媒体流时，停止接收后仍然会产生新文件的问题。

4.解决了使用UDP协议传输并录制媒体流时，服务器发送ANNOUNCE相关结束报文后，文件末尾录制不全的问题。

5.优化了守护线程的工作机制，降低录制错误率。

---

**5.0.4 (2020/11/21)**

1.增加了主界面自动监听剪贴板中的RTSP地址。

2.增加了一些简体中文翻译词条。

3.支持根据ANNOUNCE报文关键字自动停止录制。

4.优化了关闭连接的方式。

---

**5.0.3 (2020/11/20)**

很萌录制器5.0正式发布。全新的用户操作模式，带来全新的RTSP录制体验。

很萌录制器采用全新的设计理念，从根本上解决了不规则RTSP协议请求发送难、录制步骤繁琐的问题。

更少的点击次数带来更高的操作效率，可真正实现常态化“一键录制”。

重新设计的批量操作面板极大的减少了多任务场景下的人工介入频率。

---

**3.1.1 (2020/10/05)**

1.修复任务启动器计数错误的问题。

---

**3.1.0 (2020/07/19)**

1.新增任务启动器。可更高效的管理和启动多个任务。

2.新增自定义保存路径和保存文件名。

3.修复录制TCP有效载荷时，可能导致RTP头大小计算错误的一个问题。
