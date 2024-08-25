# OppseMachine

## 担当箇所

敵の移動や攻撃に関する挙動制御。

プレイヤーと敵が使用する追尾ミサイルの制御。

プレイヤーの使用する追尾ミサイルのロックオン処理。

## スクリプト

### __敵の挙動制御__

>#### __各種行動への切り替え__

敵はプレイヤーとの距離に応じて挙動が変化するように、[メゾット"Searching"](https://github.com/KuroYuki009/MechanicProjects/blob/main/Assets/NewEnemySystem/EnemyCommonManager.cs#L79-L103)でVector3.Distanceで相手との距離がどれくらいあるかを取得し、それを元に一定の距離ごとに合わせた処理に切り替わります。
処理の切り替えにはSwitch文を利用しています。

>#### __追跡の挙動__

プレイヤーとの距離がかなり離れていた場合には処理を追跡モードに切り替えます。
追尾モードに切り替わって一定時間はプレイヤーの脱出地点の方向へ走らせて、少し経ったらプレイヤーの方向へ移動するようにさせています。
<br>
(参照処理：[メゾット"Searching"](https://github.com/KuroYuki009/MechanicProjects/blob/main/Assets/NewEnemySystem/EnemyCommonManager.cs#L79-L103))

### __ロックオンミサイル__

>#### __追尾ミサイルの挙動__
追尾ミサイルの実装には、標的へ飛んでいく弾とそれらを発射するランチャーの二つで実現できています。
ランチャー側で弾を生成した時に標的のTransformを渡す事でそのオブジェクトへ自動で飛んでいきます。
<br>
(参照：[ランチャー側のスクリプト](https://github.com/KuroYuki009/MechanicProjects/blob/main/Assets/Weapon/MicroMissileSystem/MicroMissileGenerator.cs)、
[ミサイル側のスクリプト](https://github.com/KuroYuki009/MechanicProjects/blob/main/Assets/Weapon/MicroMissileSystem/MicroMissile_Weapon.cs))

>#### __ミサイルのロックオン処理__
プレイヤーが使用するミサイルは、画面上に表示されたエイムカーソルに敵を入れた上で射撃ボタンを押す事で各目標へ飛んでいきます。
これらはCanvas上に配置されているUI同士の衝突判定を利用して実装しました。<br>
仕組みとしては、敵が生成された時に敵に追従し続けるカーソルUIを非表示で生成させておき、プレイヤーがミサイルを装備した時にCanvas上でロックオン範囲となるオブジェクトが有効化された時、
その中に含まれるCollider2Dに衝突した敵カーソルは表示され、紐図けられた敵オブジェクトの情報をランチャー側に渡します。
<br>
(参照:[カーソルUIのスクリプト](https://github.com/KuroYuki009/MechanicProjects/blob/main/Assets/Weapon/MicroMissileSystem/LockOnModule/LockOnCursorConvert.cs)、
[ランチャー側のスクリプト](https://github.com/KuroYuki009/MechanicProjects/blob/main/Assets/Weapon/MicroMissileSystem/MicroMissileGenerator.cs)、
[ミサイル側のスクリプト](https://github.com/KuroYuki009/MechanicProjects/blob/main/Assets/Weapon/MicroMissileSystem/MicroMissile_Weapon.cs)))
