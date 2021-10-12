# MassTower
Tower Defense 2D Game

# **Table of Contents**
- [Technology](#technology)
- [Main Menu](#main)
- [Game Menu](#game)
- [Tower](#tower)
- [Bullet](#bullet)
- [Enemy](#enemy)
- [Grid](#grid)

## Technology <a name="technology"></a>
> ### Game Engine Unity Version 2020.3.15f2
![](https://upload.wikimedia.org/wikipedia/commons/1/19/Unity_Technologies_logo.svg)
> ### IDE Microsoft Visual Studio 2019
<img src="https://1000logos.net/wp-content/uploads/2020/08/Visual-Studio-Logo.png" width="240">


## Main Menu <a name="main"></a>
![](https://github.com/phantichchai/MassTower/blob/main/Image/main.jpg)
**UI Component**
  - `Play button`
  - `Music button`
  - `Effect button` 

## Game Menu <a name="game"></a>
![](https://github.com/phantichchai/MassTower/blob/main/Image/game.jpg)
**UI Component**
  - `Status bar` (use singleton design that makes this class can be access by entire system)
  - `Difference tower button`
  - `Speed button`
  - `Start button`

Game menu with debug grid show tile layouts for placing tower from tower button at UI. 

## Tower <a name="tower"></a>
![](https://github.com/phantichchai/MassTower/blob/main/Image/TowerClass.png)

In **Tower class**, there are several attributes such as damage, range, target etc.

There are 3 extended classes using inheritance of tower class that is archer, stone, and ice tower. 

## Bullet <a name="bullet"></a>
![](https://github.com/phantichchai/MassTower/blob/main/Image/bulletClass.png)

There are 3 extended classes using inheritance of bullet class that is arrow, stone magic, and ice magic.

In *ice magic*, there are special effect slow enemy which this effect will be apply on enemy class.

Each extended bullet class are different behavior for move transition.

## Enemy <a name="enemy"></a>
![](https://github.com/phantichchai/MassTower/blob/main/Image/enemyClass.png)

**Enemy class** 
  - There is one attribute that is *debuff class* which design by polymorphism concept for take different debuff.
  - Control by EnemyAI class, this class will call methods from enemy class such as add debuff or move position, etc. There is a game system class calculate the path (use Astar algorithm for path finding) for enemy AI which path will be store in EnemyAi class 
  
## Grid <a name="grid"></a>
![](https://github.com/phantichchai/MassTower/blob/main/Image/Grid.png)

Grid system using generic type for different type of grid. For example, Tile grid be used to placing tower, path grid for navigation etc.

## Thank you
https://www.youtube.com/c/CodeMonkeyUnity
