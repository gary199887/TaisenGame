using System.Collections;
using System.Collections.Generic;
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
        //stageData.itemList.items.Add(new Item(0, "�e", "�qB�̂��̂��B��A�qA����o�[�e���_�[�Ɍ����Ă����Ăق����ƌ���ꂽ���玝�����Ă�B"));
        //stageData.itemList.items.Add(new Item(1, "���ꂽ�O���X", "��A�qA�������Ċ��������̂��B"));
        //stageData.itemList.items.Add(new Item(2, "�A�C�X�s�b�N", "�ƂĂ����ꂢ�ȏ�ԁA�o�[�e���_�[���g���Ă���̂��B"));
        //stageData.itemList.items.Add(new Item(3, "�󂭂�", "�������Ă���A�qC�������Č����т炩���Ă����������B�������ĂĂ݂�����B"));
        //stageData.charaList.Add(new Chara(0, "�o�[�e���_�[", "�j", "��A�qA�ɑ΂��D���������Ă���B�qB�ɑ΂����܂�悭�v���Ă��Ȃ��B", "��A�qA���牽���ŋ�����Ă���Ƃ������k���󂯂����Ƃ���B���͌o�c���������܂������ĂȂ��B", new string[]{"���܂ɐȂ��O�����炢�ŁA��{�I�ɃJ�E���^�[�ɂ�����B", "�qB�������ɒ����Ԃ��Ȃ������̂�m���Ă��B", "���������ڂ������璅�ւ�����B" }));
        //stageData.charaList.Add(new Chara(1, "��A�qA", "��", "�qB�ƕt�������Ă���B�o�[�e���_�[�ƕ��C���Ă���B", "�qC�ɕ��C���Ă��邱�Ƃ���������Ă���B�؋����Ă܂Ńu�����h�i�����Ă�B", new string[] { "���݂����Ă��܂�o���ĂȂ���B", "�����́B�o�[�e���Ɠ�l�Řb���Ă���B" }));
        //stageData.charaList.Add(new Chara(2, "�qB", "�j", "��A�qA�ƕt�������Ă��čK�����Ɗ����Ă���B�o�[�e���_�[�Ə�A�qA�����ǂ����Ă���̂��C�ɐH��Ȃ�", "�e�������Ă���B��A�qA���牽���ŋ�������Ă���Ƃ������k���󂯂����Ƃ�����B", new string[] { "���ɋqC�����ɘb������ƌ����Ă�����B", "�ŏ��Ɏ��̂��������A������������󂢂Ă���B", "�����͓d�b���ĂĂ��΂炭���Ȃ�������B" }));
        //stageData.rank.records.Add(new Record());
        //StageManager.saveStage(stageData);
    }
}
