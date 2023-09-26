using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageDataIO : MonoBehaviour
{
    // ����GameObject�̓X�e�[�W�f�[�^��ǉ�����Ƃ���p�A���i��InActive
    // ���X�e�[�W�f�[�^��ݒ肵�AsaveStage���Ă���G�N�X�v���[���[�Œ��ڃt�@�C������ύX(".stageData" + stageNumber + ".json")
    Stage stageData;
    void Start()
    {


        //stageData = new Stage();
        //stageData.itemList = new ItemList();
        //stageData.itemList.items.Add(new Item(0, "�e", "�qB�̂��̂��B��A�qA����o�[�e���_�[�Ɍ����Ă����Ăق����ƌ���ꂽ���玝�����Ă�B", new Vector3(8.16f, -1.13f, 0)));
        //stageData.itemList.items.Add(new Item(1, "���ꂽ�O���X", "��A�qA�������Ċ��������̂��B", new Vector3(5.07f, -2.28f, 0)));
        //stageData.itemList.items.Add(new Item(2, "�A�C�X�s�b�N", "�ƂĂ����ꂢ�ȏ�ԁA�o�[�e���_�[���g���Ă���̂��B", new Vector3(-2.29f, -1.78f, 0)));
        //stageData.itemList.items.Add(new Item(3, "�󂭂�", "�������Ă���A�qC�������Č����т炩���Ă����������B�������ĂĂ݂�����B", new Vector3(2.95f, -0.56f, 0)));
        //stageData.charaList.Add(new Chara(0, "�o�[�e���_�[", "�j", "��A�qA�ɑ΂��D���������Ă���B�qB�ɑ΂����܂�悭�v���Ă��Ȃ��B", "��A�qA���牽���ŋ�����Ă���Ƃ������k���󂯂����Ƃ���B���͌o�c���������܂������ĂȂ��B", new string[] { "���܂ɐȂ��O�����炢�ŁA��{�I�ɃJ�E���^�[�ɂ�����B", "�qB�������ɒ����Ԃ��Ȃ������̂�m���Ă��B", "���������ڂ������璅�ւ�����B" }));
        //stageData.charaList.Add(new Chara(1, "��A�qA", "��", "�qB�ƕt�������Ă���B�o�[�e���_�[�ƕ��C���Ă���B", "�qC�ɕ��C���Ă��邱�Ƃ���������Ă���B�؋����Ă܂Ńu�����h�i�����Ă�B", new string[] { "���݂����Ă��܂�o���ĂȂ���B", "�����́B�o�[�e���Ɠ�l�Řb���Ă���B" }));
        //stageData.charaList.Add(new Chara(2, "�qB", "�j", "��A�qA�ƕt�������Ă��čK�����Ɗ����Ă���B�o�[�e���_�[�Ə�A�qA�����ǂ����Ă���̂��C�ɐH��Ȃ�", "�e�������Ă���B��A�qA���牽���ŋ�������Ă���Ƃ������k���󂯂����Ƃ�����B", new string[] { "���ɋqC�����ɘb������ƌ����Ă�����B", "�ŏ��Ɏ��̂��������A������������󂢂Ă���B", "�����͓d�b���ĂĂ��΂炭���Ȃ�������B" }));
        //stageData.rank.records.Add(new Record());
        //stageData.endTalks.Add("�����I�Ɛl�̓I�[�i�[��");
        //stageData.endTalks.Add("���@�F�qB�ƋqC�̉�b���������A�qA�Ƃ̂��Ƃ��΂炳���Ǝv��������");
        //stageData.endTalks.Add("�o�c��������肭�����ĂȂ����Ƃ�A�qA�Ɏ؋��Ȃ����邽�߂����i������̕󂭂��j���~��������");
        //stageData.endTalks.Add("�A���o�C�F�qA��������Ă��݂��̃A���o�C��������B\n����F�e�ł̎E�Q�Ɍ��������邽�߂Ɍ����J����");
        //stageData.endTalks.Add("�N���A�ł�\nZ�L�[�����ă��U���g���m�F");


        stageData = new Stage();
        stageData.itemList = new ItemList();
        stageData.itemList.items.Add(new Item(0, "�J����", "���X�̎ʐ^��i�F�̎ʐ^�Ȃǂ��������񂠂�\n�ʐ^�Ƃ��g���Ă�����̂�", new Vector3(8.16f, -1.13f, 0)));
        stageData.itemList.items.Add(new Item(1, "�ԕr", "�X�Y�������}�����Ă���\n�X�Y������}���Ȃ�Ăǂ������Ă�", new Vector3(5.07f, -2.28f, 0)));
        stageData.itemList.items.Add(new Item(2, "�", "���ꂢ�ɕۂ���Ă邪�A�g�����܂�Ă���̂�������", new Vector3(-2.29f, -1.78f, 0)));
        stageData.itemList.items.Add(new Item(3, "�y��", "�ٌ�m�̎g���Ă���y��\n�X�ɖY��Ă����������B�X��Ƃ����Ă����E�F�C�^�[���������B", new Vector3(2.95f, -0.56f, 0)));
        stageData.itemList.items.Add(new Item(4, "�i�C�t", "������������\n���̂Ɏh�����Ă������̂Ɠ����A�H���p�̃i�C�t", new Vector3(0.95f, -0.56f, 0)));

        stageData.charaList.Add(new Chara(0, "�V�F�t", "��", "�I�[�i�[�Ƃ̓r�W�l�X�p�[�g�i�[�ł���A�����Ԉꏏ�Ɏd�����Ă���B", "�ߋ��Ɍo�c�Ńg���u�����������B���݂̌o�c�͈��肵�Ă���B"));
        stageData.charaList.Add(new Chara(1, "�E�F�C�^�[", "�j", "�^�ʖڂɓ����Ă��Ď��͂���͂ƂĂ��ǂ���ۂ������Ă���B", "�^�ʖڂɓ����Ă��邪���͓������ɕs��������B"));
        stageData.charaList.Add(new Chara(2, "�ٌ�m", "�j", "�F�X�Ȑl�Ǝd�������Ă���B�d���̒���1�ł��̂��X�Ɋւ��邱�Ƃ��S�����Ă���B", "�ߋ��ɕs���Ȏ�����������Ƃ����邪�A���̍߂��B�����߂Ɏ�i��I�΂Ȃ������Ƃ�����ʂ����B"));
        stageData.charaList.Add(new Chara(3, "�ʐ^��", "��", "�L����|�X�^�[�A�ʐ^�W�ւ̓W���Ȃǂł��̂��X�̎ʐ^���B�����B", "�I�[�i�[�ɍL��Ƃ��Č_����Ă��ꂽ�B���̌��ŕٌ�m��I�[�i�[�ƃg���u���ɂȂ����B"));

        // add talks
        Talk currentTalk = new Talk();
        currentTalk.normalTalk = new List<Talks>
        {
            new Talks(new string[] { "���߂Ęb��", "�킽���̓V�F�t", "���I" }),
            new Talks(new string[] {"���ژb��", "���낻�낢���ł���" }),
        };
        currentTalk.alibi = new string[] { "�~�[�ŗ����̏����Ȃǂ����Ă܂����B", "�X��͐[��1���܂ŗ����̏����Ȃǂ����Ă܂����B" };
        currentTalk.itemTalk = new List<Talks> {
            null,
            null,
            new Talks(new string[] {"����͎��̂�����", "���i���猋�\�g���Ă��"}),
            null,
            null
    };


        stageData.charaList[0].setTalks(currentTalk);

        //// second chara
        currentTalk.normalTalk = new List<Talks> {
            new Talks(new string[] { "First Talk!", "I am waiter!", "Nice to meet you bro!" }),
            new Talks(new string[] { "Uh...", "I ... am waiter", "that's all." })

        };
        currentTalk.alibi = new string[] { "�����̒񋟂₨�q�l�̑Ή��Ȃǂ̋Ɩ����s���Ă���B", "�X����0���܂ł͐��|�Ȃǂ̕X��Ƃ�1���Ԓ��x���Ă��񂾁B" };
        currentTalk.itemTalk = new List<Talks> {
            null,
            null,
            null,
            null,
            new Talks(new string[] { "�������g���Ă�i�C�t�͑S�����̃^�C�v����", "���ɉ����ς�������Ƃ��Ȃ���" })
        };
        stageData.charaList[1].setTalks(currentTalk);

        // 3rd chara
        currentTalk.normalTalk = new List<Talks> {
             new Talks(new string[] { "�ٌ�m������Ă܂�", "�ł��邾���̋��͂͂��܂�" }),
             new Talks(new string[] { "�ȏ�ł�" })
        };
        currentTalk.alibi = new string[] { "�Ƒ��ƈꏏ�ɐH�������Ă��āA���̌�͎���ɋA��d���֌W�̂��Ƃ����Ă��܂����B" };
        currentTalk.itemTalk = new List<Talks> {
            null,
            new Talks(new string[] { "���x�����X�ɑ΂��ĉԕr�ɃX�Y������}���Ă��邱�Ƃ𒍈ӂ��Ă��܂��B" }),
            null,
            new Talks(new string[] { "���������i�g���Ă���y���ł��ˁB", "�ǂ��ɗ��Ƃ������Ǝv�����炱���������ł��ˁB", "�E�F�[�^�[���񂪌����Ă���Ă悩�����ł��B" }),
            null
        };
        stageData.charaList[2].setTalks(currentTalk);

        foreach (var strarr in currentTalk.normalTalk) {
            foreach (var str in strarr.talks) {
                Debug.Log(str);
            }
        }
        foreach (var strarr in currentTalk.itemTalk) {
            try
            {
                foreach (var str in strarr.talks)
                {
                    Debug.Log(str);
                }
            } catch {
                Debug.Log("null");
            }
        }


        // 4th chara
        currentTalk.normalTalk = new List<Talks> {
            new Talks(new string[] { "���߂܂���", "���͎ʐ^��", "��낵����" }),
            new Talks(new string[] { "�ʐ^�ȊO�ɂ��F�X����Ă��", "���̓X�Ɋւ��d������S�����Ă邩��悭�����" }),
            new Talks(new string[] { "���̂��Ƃ͂�����������" })
        };
        currentTalk.alibi = new string[] { "�ʐ^���B�����肵�Ȃ���A��Ă�����A�I�[�i�[�̎��̂��������̂�B", "���̂ɂ͂��X�̃i�C�t���h�����Ă�����B" };
        currentTalk.itemTalk = new List<Talks> {
            new Talks(new string[] { "���̃J��������", "�d��������瑁���Ԃ��Ă����Ə�����񂾂�" }),
            null,
            null,
            null,
            null
        };
        stageData.charaList[3].setTalks(currentTalk);



        stageData.rank.records.Add(new Record());
        stageData.endTalks.Add("�����I�Ɛl�͎ʐ^�Ƃ�");
        stageData.endTalks.Add("���@�F�����̍D���Ȏʐ^���B�肽���������A�I�[�i�[���ƂĂ���������������");
        stageData.endTalks.Add("�o�c��������肭�����ĂȂ����Ƃ�A�qA�Ɏ؋��Ȃ����邽�߂����i������̕󂭂��j���~��������");
        stageData.endTalks.Add("�A���o�C�F�X�Y�����̓łŎ��ʂ܂ł̎��ԂɎʐ^���B�邱�ƂŃA���o�C�������");
        stageData.endTalks.Add("����F�i�C�t�ł̎E�Q�Ɍ��������邽�߂Ɏ��񂾂��ƂŎh����");
        stageData.endTalks.Add("�N���A�ł�\nZ�L�[�����ă��U���g���m�F");

        StageManager.saveStage(stageData);
    }
}
