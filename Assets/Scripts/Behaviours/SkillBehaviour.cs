using NOX.Maga.Data.Skill;

public static class SkillBehaviour
{
    public static void Select(SkillData skill)
    {
        skill.IsEnabled = false;
        // Stop to cast or finish path and disable movement
        EventManager.RaiseOnSkillSelected();
    }

    public static void Activate(SkillData skill)
    {
        // Move to range or cast
        EventManager.RaiseOnSkillActivated();

        if (skill is IAreaTarget)
        {
            // Move to range and cast
        }

        if (skill is IEnemyTarget)
        {
            // Verify target, if enemy move range and cast
        }
    }

    public static void Reset(SkillData skill)
    {
        skill.IsEnabled = true;
    }
}