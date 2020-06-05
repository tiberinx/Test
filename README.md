тестовое задание для Junior Unity Developer

### Какие пункты из ТЗ были выполнены?

* За сбитие вражеских кораблей игрок должен получать очки, которые должны отображаться в UI.

* Корабль игрока должен получать урон от вражеских выстрелов. Количество очков прочности должно отображаться в UI.

* После уничтожения корабля должно появляться окно поражения с информацией о количестве полученных очков и кнопкой “начать заново”.

* Корабль игрока не должен вылетать за пределы экрана.

* Необходимо добавить новый тип оружия - ракеты

* Необходимо добавить еще как минимум 2 типа вражеских кораблей с различным поведением и набором оружия: 
  * Как минимум один из кораблей должен стрелять ракетами
  
  
 Код я снабдил комментариями, на мой взгляд, понятными для стороннего наблюдателя
 
 ### Были внесены следующие изменения в файлах и папках (перечень согласно иерархии):
 
 **Prefabs -> Spaceships -> Enemy**
   * Добавлены два префаба, в префабы добавлен Reward.cs

**Prefabs -> Spaceships -> PlayerSpaceship**
   * В префаб добавлены PlayerHealth.cs и PlayerMoveBoundaries.cs
        
**Prefabs -> Weapons**
   * Добавлен префаб MissileRack
        
**Prefabs -> Weapons -> Projectiles**
   * Добавлен префаб Missile. В префаб добавлен скрипт Missile.cs
        
**Scripts -> Gameplay -> Helpers**
   * Добавлены скрипты: GameOverScreen.cs, HealthBar.cs, PlayerHealth.cs, PlayerMoveBoundaries.cs, PlayerScore.cs, Reward.cs
        
**Scripts -> Gameplay -> ShipControllers -> CustomControllers**
   * EnemyShipController.cs: Добавлен код для движения противников по другим направлениям
        
**Scripts -> Gameplay -> Spaceships**
   * Spaceship.cs: Добавлен код для реализации смерти игрока, подсчёта очков и здоровья кораблей

**Scripts -> Gameplay -> Weapons -> Projectiles -> CustomProjectiles**
   * Добавлен скрипт Missile.cs
        
**Sprites -> Spaceships**
   * Добавлен спрайт Missile
        
        
