using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDataIO : MonoBehaviour
{
    // このGameObjectはステージデータを追加するとき専用、普段はInActive
    // 一回ステージデータを設定し、saveStageしてからエクスプローラーで直接ファイル名を変更(".stageData" + stageNumber + ".json")
    Stage stageData;
    void Start()
    {
        //stageData = new Stage();
        //stageData.itemList = new ItemList();
        //stageData.itemList.items.Add(new Item(0, "銃", "客Bのものだ。常連客Aからバーテンダーに見せてあげてほしいと言われたから持っきてる。"));
        //stageData.itemList.items.Add(new Item(1, "割れたグラス", "常連客Aが酔って割ったものだ。"));
        //stageData.itemList.items.Add(new Item(2, "アイスピック", "とてもきれいな状態、バーテンダーが使ってるものだ。"));
        //stageData.itemList.items.Add(new Item(3, "宝くじ", "当たっている、客Cが酔って見せびらかしていたそうだ。俺も当ててみたいよ。"));
        //stageData.charaList.Add(new Chara(0, "バーテンダー", "男", "常連客Aに対し好感を持っている。客Bに対しあまりよく思っていない。", "常連客Aから何かで脅されているという相談を受けたことある。実は経営が少しうまくいってない。", new string[]{"たまに席を外すぐらいで、基本的にカウンターにいたよ。", "客Bが昼頃に長時間いなかったのを知ってるよ。", "お酒をこぼしたから着替えたよ。" }));
        //stageData.charaList.Add(new Chara(1, "常連客A", "女", "客Bと付き合っている。バーテンダーと浮気している。", "客Cに浮気していることを脅かされている。借金してまでブランド品買ってる。", new string[] { "飲みすぎてあまり覚えてないよ。", "昼頃は。バーテンと二人で話してたよ。" }));
        //stageData.charaList.Add(new Chara(2, "客B", "男", "常連客Aと付き合っていて幸せだと感じている。バーテンダーと常連客Aが仲良くしているのが気に食わない", "銃を持っている。常連客Aから何かで脅かされているという相談を受けたことがある。", new string[] { "朝に客Cから夜に話があると言われていたよ。", "最初に死体を見つけた、小さい穴が二つ空いてたよ。", "昼頃は電話しててしばらくいなかったよ。" }));
        //stageData.rank.records.Add(new Record());
        //StageManager.saveStage(stageData);
    }
}
