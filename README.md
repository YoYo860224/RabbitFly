# RabbitFly
The Game Design Project  
By NTUST CSIE Student:

* B10415049 陳祐丞
* B10415048 楊宗儒
* B10415047 陳重佑
* B10415031 廖晨竹
* B10415025 洪昱翔



# Setup
* Open with Unity2017.1.1f1.
* add Tag   
```
0. Rabbit
1. Ground
2. Trap
```
* add Layer  
```
8. Rabbit
9. Ground
10. Trap
```

* add Layer and Tag to what You want do
* Build with PC 

# Info
* 除了 brokePlatform 其他的機關觸發腳本皆在 rabbit 下面，皆以 layer 判別
* 結束 UI 不寫在 Rabbit 裡，由 UI 管 UI
* 現在在兔子裡 CheckTouchGround 和 GroundCheck 一樣功能，但還是先不要刪掉
# Some prefab need set
* platform_cont
    * 可以拉長，但記得改 Collider 的長度