・チームB：ブラック企業　
・ゲーム名：街の探偵
・メンバー
　22CI0217　黒沼　諒太
・担当箇所
	・タイトルのスクリプトやUI配置
　	・ステージ4シナリオ作成
	
　22CI0223　三五　誠
・担当箇所
　	・解答の戻るボタン追加
	・ステージ5のシナリオ関係
　22CI0225　清水　航大
・担当箇所
　　　　 ・企画進行：チームリーダーとして進捗確認や役割分担などを担当
	・システム変更の指示
	　-回答からの戻るボタン
	　-会話システムの変更およびそれによるステージ1～3のシナリオ調整
	　-アイテムリスト・人物情報
	　-ゲーム時間の表示
	　-ステージ選択後プレイ前に流れる導入会話を指示・ステージ1～3の導入会話
　22CI0226　陳　慕　恒
・担当箇所
　後期授業からの変更点（スクリプト）：
	メインゲーム：
	- アイテム情報ページ追加
	- 人物情報ページ追加
		- 元のキャラと別のcorpse（死体）クラス実装
	- 会話システム改造
		- 問題の選択
		- 会話回数によって特定会話が変化できる仕様追加
		- 各アイテムについて聞きること、内容はキャラごとに設定できる
		- 特定会話後他人の証言についてという質問ができるトリガー実装
	- 情報ページにゲーム時間表示実装
	- メインゲーム開始時に流す導入会話実装
	- 以上の変更点に応じてStageクラス(jsonで読み書きするクラス)の構造変更
	

=====================================================================================
・操作方法
キー（キーボード操作/ゲームパッド）		　	役割
-----------------------			-------------------------------------
カーソルキー	/	LStick			プレイヤ移動
ZキーorEnterキー	/	Aボタン			確定/選択
Xキー		/	Bボタン			キャンセル
ESCキー		/	Menuボタン		ゲーム終了

=====================================================================================
・独自に実装した要素/PRポイント
 名前：22CI0226　陳　慕　恒
  ・ 細かく設定できる会話→証言について聞く回数ごとに違う会話を設定できる、その回数が他人のEX質問のトリガーにもなれる。
=====================================================================================
・素材
　背景：みんちりえ（ https://min-chi.material.jp/ ）
　人物：SilhouetteDesign(https://kage-design.com/)
  音:
     タイトルSE:効果音ラボ(https://soundeffect-lab.info/sound/button/)
     タイトルBGM:甘茶の音楽工房(https://amachamusic.chagasi.com/)
     ゲームBGM、SE:魔王魂（https://maou.audio/）
	
 　