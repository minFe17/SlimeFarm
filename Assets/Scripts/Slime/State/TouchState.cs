using UnityEngine;
using Utils;

public class TouchState : SlimeState
{
    float _touchStateTime;

    public override void OnEnter(Slime slime)
    {
        base.OnEnter(slime);
        _state = EStateType.Touch;
        _slime.Animator.SetTrigger("doTouch");
        _slime.MakeJam();
        PlayTouchSound();
        _slime.AddExp();
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

    void PlayTouchSound()
    {
        AudioClipManager audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        audioClipManager.PlaySFXSound(ESFXSoundType.Touch);
    }
}