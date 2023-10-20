[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/CibnTZFQ)

# Project 2 Report

Read the [project 2
specification](https://github.com/COMP30019/Project-2-Specification) for
details on what needs to be covered here. You may modify this template as you see fit, but please
keep the same general structure and headings.

Remember that you must also continue to maintain the Game Design Document (GDD)
in the `GDD.md` file (as discussed in the specification). We've provided a
placeholder for it [here](GDD.md).

## Table of Contents

* [Evaluation Plan](#evaluation-plan)
* [Evaluation Report](#evaluation-report)
* [Shaders and Special Effects](#shaders-and-special-effects)
* [Summary of Contributions](#summary-of-contributions)
* [References and External Resources](#references-and-external-resources)


## Evaluation Plan

TODO (due milestone 1) - see specification for details

### 1: Evaluation Techniques and Tasks
Evaluation Techniques:
  - Think aloud. 
    - Description: This technique involves players verbalizing their thoughts, feelings, and decisions in real-time as they play the game.
    - Implementation: Inform players before they start the game to continuously voice their thoughts while playing. Record their feedback, either via audio recording or by having a facilitator take notes.
    - Benefits: Captures immediate reactions, insights into player decision-making processes, and potential areas of confusion.
  - Post-task walkthrough.
    - Description: After completing certain tasks or the entire game, players walk the evaluator through their experiences, explaining their actions and decisions.
    - Implementation: Upon task completion, engage players in a structured discussion, prompting them to reflect on specific decisions, challenges faced, and their overall experience.
    - Benefits: Allows for deeper insights into the player's experience and strategy, understanding areas of the game that might need improvement, and gauging the intuitiveness of the gameplay.
  - Questionnaires.
    - Description: Structured forms that players fill out, providing feedback on their gaming experience.
    - Implementation: Create a mix of closed-ended (e.g., Likert scale) and open-ended questions to capture quantitative and qualitative data. These can be provided at the end of gameplay or at specific checkpoints.
    - Benefits: Provides a structured way to collect player feedback, allows for easy data aggregation, and can reach a large number of players.

Tasks:
  - Attempt to complete the game and read the storyline.
    - Assess the overall flow, difficulty, and coherence of the game's narrative.
  - Try multiple challenges using different card combinations.
    - Evaluate the game's versatility, card balance, and strategy depth.
  - Fill out questionnaires to provide feedback on the gaming experience and satisfaction.
    - Capture structured feedback on gameplay, graphics, user interface, and overall satisfaction.

### 2: Participants

Recruitment Methods:
  - Recruit friends for testing.
    - Friends are more likely to provide candid feedback and are generally more accessible and willing to participate. Additionally, they might be more forgiving of initial bugs or issues.
  - Post messages on social platforms to attract interested players.
    - Reaching out to a wider and more diverse audience can provide a richer set of feedback. Engaging with online gaming communities can also help create a buzz around the game.

Qualifying Criteria:
  - Age: 14 years or older.
    - To ensure players have a certain level of cognitive maturity and comprehension to engage with the game and provide valuable feedback. Additionally, it can be an effort to adhere to certain digital privacy regulations for minors.
  - Gaming Experience: Players with various levels of gaming experience, including novices and experienced gamers.
    - Including both novices and experienced gamers ensures that the game caters to a wide audience. Novices can provide feedback on the game's learning curve, while experienced gamers can comment on depth and strategy.

### 3: Data Collection
Data Types:
  - Questionnaire data. This encompasses data gathered directly from players through questionnaires, capturing their feedback, sentiments, and opinions about the game.
  - In-game data. This involves data automatically recorded while players engage with the game, capturing their behaviors, choices, and patterns.

Data Collection Tools:
  - Online questionnaire platform: SurveyMonkey.
    - Embed a link to the survey within the game's main menu or send it via email to registered users.
  - In-game analytics tool: Unity Analytics.
     - Export data from both SurveyMonkey and Unity Analytics into Excel formats.
  - Excel spreadsheets.
    - Export data from both SurveyMonkey and Unity Analytics into Excel formats. Utilize Excel’s powerful data analysis tools, including pivot tables, charts, and formulas, to process and analyze the gathered data. This is especially useful for cross-referencing data from both sources and drawing insights.

### 4: Data Analysis
Analysis Methods:
  - Data visualization: Create charts and graphs to visualize data, including player behavior and questionnaire results.
  - Statistical analysis: Use statistical tools to analyze data, such as averages, standard deviations, and correlations.

Metrics:
  - Completion rate. A bar graph that showcases the percentage of players who completed a certain level, stage, or the entire game.
  - Card selection rate. A pie chart or a bar graph depicting which cards were most and least selected by players during the game. This could help in understanding player preferences and strategy.
  - Satisfaction. A histogram that displays the distribution of players' satisfaction levels. This could range from 'very unsatisfied' to 'very satisfied'.
  - Common issues. A bar chart representing the frequency of common issues faced by players. The issues can be categorized based on their type like technical, gameplay, etc.

### 5. Timeline:

Phase 1: Testing and Bug Fixes (09/10 - 12/10)
  - Developers conduct game testing.
  - Implement bug fixes.

Phase 2: Questionnaire Preparation and Participant Recruitment (12/10 - 14/10)
  - Analysis which data needs to be collected.
  - Design a questionnaire to collect user feedback and insights.
  - Recruit participants from various sources.

Phase 3: User Testing (14/10 - 17/10)
  - Invite participants to play the game.
  - Collect feedback during user testing sessions.

Phase 4: Data Analysis (17/10 - 20/10)
  - Analyze data to identify the areas for improvement.

Phase 5: Final Game Polish Based on Feedback (20/10 - 31/10)
  - Implement final adjustments and refinements to enhance the game based on user feedback.
  - Prepare the final version of the game for release.

### 6. Responsibilities: 
| Responsibilities |  |
| ----- | -------- |
| Testing | Jingxuan Liu |
|Debug| Haoxuan Ying, Ling Bao
|Interface beautification| Zeyue Xu
|Analysis data| Ling Bao
|Questionnaire making| Jingxuan Liu, Zeyue Xu
|Participant Recruitment| Haoxuan Ying

## Evaluation Report

TODO (due milestone 3) - see specification for details

## Shaders and Special Effects

### <strong>--Shaders </strong>
#### <strong><span style="color:Aqua">Shader1: Fade Out Effect(CG)</strong>
<p align="center">
  <img src="MarkdownResource\fadeOut.gif", width = 500>
</p>

#### <strong>FilePath: Assets\Shader\FadeOut.shader</strong>

#### <strong>Associated FilePath: Assets\Shader\Scripts\Camera\MotionBlurEffect.cs</strong>


For a top down 2D game, it is common for players to be obstructed by scene objects. The FadeOut shader is designed to achieve semi transparent interaction when the player's character is behind other scene objects, so that players can always see their position clearly, providing a better visual and gaming experience.

#### <strong>Core Principle：</strong>

- Occlusion Detection: The shader leverages the collider of a child object to detect if the player is obscured by other objects.

- Opacity Adjustment: Depending on the result of the occlusion detection, it dynamically adjusts the opacity of the object.

<p align="center">
  <img src="MarkdownResource\fadeOuthitbox.png", width = 500>
</p>


#### <strong>Code Breakdown: </strong>

```c#
// in MotionBlurEffect.cs


void OnTriggerEnter2D(Collider2D collider)
{
  if (collider.gameObject.tag == "Tree")
  {   
      // Change the transparency of the corresponding item when the player enters the collision box
      AdjustTreeTransparency(collider.transform.parent.gameObject, TRANSPARENT_VALUE);
  }
}
void OnTriggerExit2D(Collider2D collider)
{
  if (collider.gameObject.tag == "Tree")
  {
    // Restore the transparency of the corresponding item when the player leaves the collision box
    AdjustTreeTransparency(collider.transform.parent.gameObject, 1); 
  }
}

void AdjustTreeTransparency(GameObject tree, float transparencyValue)
{
  Material treeMaterial = tree.GetComponent<SpriteRenderer>().material;
  treeMaterial.SetFloat("_Transparency", transparencyValue);
}
```


In FadeOut.shader, we primarily have:

1. Texture & Variables Properties: 
- _MainTex: Represents the main texture of the object.
- _Transparency: Controls the opacity of the object. The Range(0, 1) makes sure that in the Unity inspector, you can only set its value between 0 (completely transparent) and 1 (completely opaque).
2. SubShader:
```c#
Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
LOD 100
```
- Due to the fact that the translucent effect we create is adjusted based on the original material of the object, the transparency effect should be rendered after all opaque objects.
- I set LOD to 100 is a fairly standard value for shaders which does not take up too much rendering resources

<strong> In PASS section: </strong>
```c#
Blend SrcAlpha OneMinusSrcAlpha
```
-  This line specifies the blending mode used for transparent objects. This is very important for 2D materials that use png format images as sprite materials. When unity cannot correctly reflect transparency, some pixels set to transparency may present unexpected color blocks that should not appear. This is not included in unity default settings and can be ignored by developers.


- Main part:
```c#
fixed4 frag (v2f i) : SV_Target
{
  fixed4 col = tex2D(_MainTex, i.uv);
  col.a *= _Transparency;
  return col;
}
```
The texture is sampled using the UV coordinates and alpha (transparency) of the color is multiplied by _Transparency. Finally, the modified color value col is returned. This color will be written to the current render target (due to the : SV_Target in the function declaration). The blending mode set in the shader (Blend SrcAlpha OneMinusSrcAlpha) will then determine how this color blends with the colors already in the render target.

In summary, the FadeOut shader allows us to adjust the transparency of an object dynamically. The shader samples the main texture, multiplies the sampled color's alpha by the _Transparency value, and then outputs the final color. The blending mode ensures that the transparent parts of the object blend smoothly with the background.


#### <strong><span style="color:Aqua">Shader2: Dash Blur Effect(CG)</strong>
<p align="center">
  <img src="MarkdownResource\dashBlurEffect.gif", width = 500>
</p>

#### <strong>FilePath: Assets\Shader\MotionBlurEffect.shader</strong>
#### <strong>Associated FilePath: 

- Assets\Shader\Scripts\Player\UpdateShaderWithPosition.cs
- Assets\Shader\Scripts\Player\PlayerMovement.cs
</strong>


The MotionBlurEffect shader is engineered to incorporate a dynamic blur effect into the game. As the player executes a dash maneuver, the surrounding objects on the ground( include Player) becomes blurred, offering dynamic visual feedback for the dashing motion. 

#### <strong>Core Principle：</strong>

- Render Texture: To reduce computational overhead and enhance performance, a low-resolution render texture is used.
- Dynamic Blurring: Based on the player's direction and velocity, a blur effect is computed and applied.

#### <strong>Code Breakdown: </strong>

```c#
// in PlayerMovement.cs

private void StartDash(Vector2 moveInput)
{
    isDashing = true;

    // when the player starts dashing, capture the direction of dashing
    dashDirection = moveInput.normalized;

    // change blurAmount to active blur fx, set blur direction to dash direction
    cameraBlurEffect.blurAmount = blurStrength;
    cameraBlurEffect.blurDirection = dashDirection;


    StartCoroutine(DashCoroutine());
}
    
private IEnumerator DashCoroutine()
{
    float startTime = Time.time;

    while (Time.time < startTime + 0.1f) // 0.1f is time of dash
    {
        rb.velocity = dashDirection.normalized * dashDistance / 0.1f; 
        yield return null;
    }

    isDashing = false;
        
    // when the player finished dashing, reset blurAmount to zero
    cameraBlurEffect.blurAmount = 0;
}

```

When the blurAmount and blurDirection values are modified by the PlayerMovement.cs script, the OnRenderImage method in MotionBlurEffect.cs utilizes these values:

```c#
// in MotionBlurEffect.cs

void OnRenderImage(RenderTexture src, RenderTexture dest)
{
    if (blurMaterial)
    {   
        // Create a low-resolution temporary RenderTexture to render effects
        RenderTexture tempRT = RenderTexture.GetTemporary(src.width / 2, src.height / 2);
        Graphics.Blit(src, tempRT);

        // Setting the texture, blur amount, and blur direction for the shader material
        blurMaterial.SetTexture("_MainTex", tempRT);
        blurMaterial.SetFloat("_BlurAmount", blurAmount);
        blurMaterial.SetVector("_BlurDirection", blurDirection);
        Graphics.Blit(src, dest, blurMaterial);

        // Release the temporary RenderTexture
        RenderTexture.ReleaseTemporary(tempRT);
    }
    else
    {
        Graphics.Blit(src, dest);
    }
}
```
The primary idea behind many blur techniques is to sample the texture at multiple points around the current pixel, then average these samples to get the final color. The more samples you take, and the further away from the original pixel, the stronger the blur.

<p align="center">
  <img src="MarkdownResource\blureffectclip.png", width = 500>
</p>

In MotionBlurEffect.shader, we primarily have:

1. Texture & Variables Properties: 

- _MainTex: The main texture that the shader will process.
- _BlurAmount: Controls how strong the blur effect is.
- _BlurDirection: The direction of the blur based on player dash direction.

2. Main section of the shader:

```c#
fixed4 frag (v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv) * i.color;
    col += tex2D(_MainTex, i.uv + _BlurDirection * _BlurAmount * 0.002) * i.color;
    col += tex2D(_MainTex, i.uv - _BlurDirection * _BlurAmount * 0.002) * i.color;
    col /= 3;
    return col;
}
```
In many blur techniques, a useful method is to sample the texture at multiple points around the current pixel, and then average these samples to obtain the final color. Here, I use the player's dashdirection as the blur square and sample the textures (MainTex) at an offset (+/-_BlurDirection * _BlurAmount) base on I.UV. Then average out the three samples by dividing by 3. This offset creates a blur effect in both directions of the player's sprint path.

## Summary of Contributions

TODO (due milestone 3) - see specification for details

## References and External Resources

TODO (to be continuously updated) - see specification for details
