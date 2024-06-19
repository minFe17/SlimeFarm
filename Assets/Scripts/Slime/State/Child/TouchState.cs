using UnityEngine;
using Utils;

public class TouchState : SlimeState
{
    IGrowSlime _slimeGrow;
    float _touchStateTime;

    public override void OnEnter(ISlimeState slime)
    {
        base.OnEnter(slime);
        _state = EStateType.Touch;
        _slime.Animator.SetTrigger("doTouch");
        _slimeGrow = (Slime)_slime;
        Touch();
        _touchStateTime = Random.Range(2f, 4f);
    }

    public override void MainLoop()
    {
        CheckTime();
    }

    protected override void CheckTime()
    {
        _time += Time.deltaTime;
        if (_time >= _touchStateTime)
            _slime.ChangeState(new WalkState());
    }

    void Touch()
    {
        _slimeGrow.MakeJam();
        PlayTouchSound();
        _slimeGrow.AddExp();
    }

    void PlayTouchSound()
    {
        AudioClipManager audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        audioClipManager.PlaySFXSound(ESFXSoundType.Touch);
    }
}