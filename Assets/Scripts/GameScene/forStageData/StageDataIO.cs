using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        //stageData.itemList.items.Add(new Item(0, "銃", "客Bのものだ。常連客Aからバーテンダーに見せてあげてほしいと言われたから持っきてる。", new Vector3(8.16f, -1.13f, 0)));
        //stageData.itemList.items.Add(new Item(1, "割れたグラス", "常連客Aが酔って割ったものだ。", new Vector3(5.07f, -2.28f, 0)));
        //stageData.itemList.items.Add(new Item(2, "アイスピック", "とてもきれいな状態、バーテンダーが使ってるものだ。", new Vector3(-2.29f, -1.78f, 0)));
        //stageData.itemList.items.Add(new Item(3, "宝くじ", "当たっている、客Cが酔って見せびらかしていたそうだ。俺も当ててみたいよ。", new Vector3(2.95f, -0.56f, 0)));
        //stageData.charaList.Add(new Chara(0, "バーテンダー", "男", "常連客Aに対し好感を持っている。客Bに対しあまりよく思っていない。", "常連客Aから何かで脅されているという相談を受けたことある。実は経営が少しうまくいってない。", new string[] { "たまに席を外すぐらいで、基本的にカウンターにいたよ。", "客Bが昼頃に長時間いなかったのを知ってるよ。", "お酒をこぼしたから着替えたよ。" }));
        //stageData.charaList.Add(new Chara(1, "常連客A", "女", "客Bと付き合っている。バーテンダーと浮気している。", "客Cに浮気していることを脅かされている。借金してまでブランド品買ってる。", new string[] { "飲みすぎてあまり覚えてないよ。", "昼頃は。バーテンと二人で話してたよ。" }));
        //stageData.charaList.Add(new Chara(2, "客B", "男", "常連客Aと付き合っていて幸せだと感じている。バーテンダーと常連客Aが仲良くしているのが気に食わない", "銃を持っている。常連客Aから何かで脅かされているという相談を受けたことがある。", new string[] { "朝に客Cから夜に話があると言われていたよ。", "最初に死体を見つけた、小さい穴が二つ空いてたよ。", "昼頃は電話しててしばらくいなかったよ。" }));
        //stageData.rank.records.Add(new Record());
        //stageData.endTalks.Add("正解！犯人はオーナーだ");
        //stageData.endTalks.Add("動機：客Bと客Cの会話が聞こえ、客Aとのことをばらされると思ったから");
        //stageData.endTalks.Add("経営も少し上手くいってないことや、客Aに借金癖があるためお金（当たりの宝くじ）が欲しかった");
        //stageData.endTalks.Add("アリバイ：客Aを説得してお互いのアリバイを作った。\n凶器：銃での殺害に見せかけるために穴を開けた");
        //stageData.endTalks.Add("クリアです\nZキー押してリザルトを確認");


        stageData = new Stage();
        Corpse corpse = new Corpse();
        corpse.name = "オーナー";
        corpse.gender = "男";
        corpse.bodyInfo = "死体にナイフ、死亡推定時刻と血液の状態が少しあわない";
        corpse.secret = "なんかオーナーの秘密";
        corpse.relationShip = "オーナーの人間関係等";
        stageData.corpse = corpse;


        stageData.itemList = new ItemList();
        stageData.itemList.items.Add(new Item(0, "カメラ", "お店の写真や景色の写真などがたくさんある\n写真家が使っているものだ", new Vector3(-1.45f, -0.78f, 0)));
        stageData.itemList.items.Add(new Item(1, "花瓶", "スズランが挿さっていた\nスズランを挿すなんてどうかしてる", new Vector3(4.236f, 0.0f, 0)));
        stageData.itemList.items.Add(new Item(2, "包丁", "きれいに保たれてるが、使い込まれているのが分かる", new Vector3(7.76f, 0.0f, 0)));
        stageData.itemList.items.Add(new Item(3, "ペン", "弁護士の使っているペン\n店に忘れていたそうだ。閉店作業をしていたウェイターが見つけた。", new Vector3(1.1f, -0.191f, 0)));
        stageData.itemList.items.Add(new Item(4, "ナイフ", "高級感がある\n死体に刺さっていたものと同じ、食事用のナイフ", new Vector3(-4.1797f, -2.784f, 0)));

        stageData.charaList.Add(new Chara(0, "シェフ", "女", "オーナーとはビジネスパートナーであり、長い間一緒に仕事している。", "過去に経営でトラブルがあった。現在の経営は安定している。"));
        stageData.charaList.Add(new Chara(1, "ウェイター", "男", "真面目に働いていて周囲からはとても良い印象を抱かれている。", "真面目に働いているが実は働き方に不満がある。"));
        stageData.charaList.Add(new Chara(2, "弁護士", "男", "色々な人と仕事をしている。仕事の中の1つでこのお店に関することも担当している。", "過去に不正な取引をしたことがあるが、その罪を隠すために手段を選ばなかったという一面を持つ。"));
        stageData.charaList.Add(new Chara(3, "写真家", "女", "広告やポスター、写真展への展示などでこのお店の写真を撮った。", "オーナーに広報として契約を提案された。その件で弁護士やオーナーとトラブルになった。"));

        // add talks
        Talk currentTalk = new Talk();
        currentTalk.normalTalk = new List<Talks>
        {
            new Talks(new string[] { "初めて話す", "わたしはシェフ", "よろ！" }),
            new Talks(new string[] {"二回目話す", "そろそろいいでしょ" }),
        };
        currentTalk.alibi = new string[] { "厨房で料理の準備などをしてました。", "閉店後は深夜1時まで翌日の準備などをしてました。" };
        currentTalk.itemTalk = new List<Talks> {
            null,
            null,
            new Talks(new string[] {"それは私のだけど", "普段から結構使ってるよ"}),
            null,
            null
    };
        currentTalk.qa.question = new string("ウェイターの証言について聞く");
        currentTalk.qa.answer = new string[] { "自分じゃないよ", "言ったはずだ", "ずっと厨房にいたよ"};
        currentTalk.qa.trigger = new Trigger(1, 2);


        stageData.charaList[0].setTalks(currentTalk);

        //// second chara
        currentTalk = new Talk();
        currentTalk.normalTalk = new List<Talks> {
            new Talks(new string[] { "First Talk!", "I am waiter!", "Nice to meet you bro!" }),
            new Talks(new string[] { "Uh...", "I ... am waiter", "that's all." }),
            new Talks(new string[] {"そういえばシェフが犯人だと思います", "店のこと一番知ってる人だから"})
        };
        currentTalk.alibi = new string[] { "注文の提供やお客様の対応などの業務を行ってたよ。", "閉店から0時までは清掃などの閉店作業を1時間程度してたんだ。" };
        currentTalk.itemTalk = new List<Talks> {
            null,
            null,
            null,
            null,
            new Talks(new string[] { "うちが使ってるナイフは全部このタイプだよ", "特に何も変わったことがないね" })
        };

        currentTalk.qa.question = new string("見つめる");
        currentTalk.qa.answer = new string[] {"....FxxK! what's ur problem, man?", "Stop staring at me!"};
        currentTalk.qa.trigger = new Trigger(1, 0);

        stageData.charaList[1].setTalks(currentTalk);

        // 3rd chara
        currentTalk = new Talk();
        currentTalk.normalTalk = new List<Talks> {
             new Talks(new string[] { "弁護士をやってます", "できるだけの協力はします" }),
             new Talks(new string[] { "以上です" })
        };
        currentTalk.alibi = new string[] { "家族と一緒に食事をしていて、その後は自宅に帰り仕事関係のことをしていました。" };
        currentTalk.itemTalk = new List<Talks> {
            null,
            new Talks(new string[] { "何度かお店に対して花瓶にスズランを挿していることを注意しています。" }),
            null,
            new Talks(new string[] { "自分が普段使っているペンですね。", "どこに落としたかと思ったらここだったですね。", "ウェーターさんが見つけてくれてよかったです。" }),
            null
        };

        currentTalk.qa.question = new string("写真家の証言について聞く");
        currentTalk.qa.answer = new string[] { "普通に注意しただけですよ", "オーナー本人になんの恨みもない", "そもそも恨めむほど親しい関係でもないですし。" };
        currentTalk.qa.trigger = new Trigger(3, 2);
        stageData.charaList[2].talks = currentTalk;

        //foreach (var strarr in currentTalk.normalTalk) {
        //    foreach (var str in strarr.talks) {
        //        Debug.Log(str);
        //    }
        //}
        //foreach (var strarr in currentTalk.itemTalk) {
        //    try
        //    {
        //        foreach (var str in strarr.talks)
        //        {
        //            Debug.Log(str);
        //        }
        //    } catch {
        //        Debug.Log("null");
        //    }
        //}


        // 4th chara
        currentTalk = new Talk();
        currentTalk.normalTalk = new List<Talks> {
            new Talks(new string[] { "初めまして", "私は写真家", "よろしくね" }),
            new Talks(new string[] { "写真以外にも色々やってるよ", "この店に関わる仕事も一つ担当してるからよく来るよ" }),
            new Talks(new string[] { "弁護士はオーナーに対して不満があると思う", "スズランとかいつもオーナーにどうこう言ってるし", "正直迷惑だった" }),
            new Talks(new string[] { "もう特に話すことはないかな"})
        };
        currentTalk.alibi = new string[] { "写真を撮ったりしながら帰宅していたら、オーナーの死体を見つけたのよ。", "死体にはお店のナイフが刺さっていたわ。" };
        currentTalk.itemTalk = new List<Talks> {
            new Talks(new string[] { "私のカメラだね", "仕事道具だから早く返してくれると助かるんだが" }),
            null,
            null,
            null,
            null
        };

        currentTalk.qa.question = new string("なにか聞く");
        currentTalk.qa.answer = new string[] {"何かって?", "???", "......?????????"};
        currentTalk.qa.trigger = new Trigger(3, 3);


        stageData.charaList[3].talks = currentTalk;



        stageData.rank.records.Add(new Record());
        stageData.endTalks.Add("正解！犯人は写真家だ");
        stageData.endTalks.Add("動機：自分の好きな写真が撮りたかったが、オーナーがとてもしつこかったから");
        stageData.endTalks.Add("経営も少し上手くいってないことや、客Aに借金癖があるためお金（当たりの宝くじ）が欲しかった");
        stageData.endTalks.Add("アリバイ：スズランの毒で死ぬまでの時間に写真を撮ることでアリバイを作った");
        stageData.endTalks.Add("凶器：ナイフでの殺害に見せかけるために死んだあとで刺した");
        stageData.endTalks.Add("クリアです\nZキー押してリザルトを確認");
        StageManager.loadStage(100);
        StageManager.saveStage(stageData);
    }
}
