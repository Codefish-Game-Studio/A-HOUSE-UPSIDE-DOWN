using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Text dialogueTxt;
    public GameObject dialogueBox, citizen, detective;
    public Sprite ballonSprite, ballonSpriteFlipped;
    public Sprite[] citizenSprites, detectiveSprites;
    private bool isProceeding = false;
    public static int lineIndex;
    private int maxLineIndex;

    void Start()
    {
        string scene = SceneManager.GetActiveScene().name;

        switch (scene)
        {
            case "IntroCutscene1":
                maxLineIndex = 2;
                break;
            case "IntroCutscene2":
                maxLineIndex = 6;
                break;
            case "EndingCutscene":
                maxLineIndex = 10;
                break;
            default:
                maxLineIndex = int.MaxValue;
                break;
        }

        PassDialogue();
    }

    private void Update()
    {
        if (!isProceeding && Input.GetMouseButtonDown(0) && lineIndex <= maxLineIndex)
        {
            StartCoroutine(Proceeding());
        }
    }

    private IEnumerator Proceeding()
    {
        isProceeding = true;
        PassDialogue();
        yield return new WaitForSeconds(0.2f);
        isProceeding = false;
    }

    private void ShowDialogue(string line)
    {
        dialogueTxt.text = line;
    }

    private void PassDialogue()
    {
        switch (lineIndex)
        {
            case 0:
                ChangeSprite(citizen, citizenSprites[3]);
                ChangeSprite(detective, detectiveSprites[20]);
                ShowDialogue("Hello? Is anybody there? Thieves have turned my house completely <b>upside down</b>!");
                AnimateBox();
                AudioManager.Instance.ChangeMusic(AudioManager.Instance.gameMusic);
                lineIndex++;
                break;
            case 1:
                FlipBox(ballonSpriteFlipped);
                ChangeSprite(citizen, citizenSprites[4]);
                ChangeSprite(detective, detectiveSprites[19]);
                ShowDialogue("This is [REDACTED]. Whats your address? We'll get there as soon as possible.");
                AnimateBox();
                lineIndex++;
                break;
            case 2:
                SceneLoader.Instance.LoadScene("IntroCutscene2", 1f);
                lineIndex++;
                break;
            case 3:
                FlipBox(ballonSpriteFlipped);
                ChangeSprite(citizen, citizenSprites[5]);
                ChangeSprite(detective, detectiveSprites[10]);
                ShowDialogue("We're here, ma'am. Can you describe what happened?");
                AnimateBox();
                lineIndex++;
                break;
            case 4:
                FlipBox(ballonSprite);
                ChangeSprite(citizen, citizenSprites[4]);
                ShowDialogue("Someone broke into my house! They certainly took something! I have a photo of the house before the robbery! Maybe it could help you find out what was stolen.");
                AnimateBox();
                lineIndex++;
                break;
            case 5:
                FlipBox(ballonSpriteFlipped);
                ChangeSprite(citizen, citizenSprites[5]);
                ChangeSprite(detective, detectiveSprites[16]);
                ShowDialogue("(Well, let's take a look at it...)");
                AnimateBox();
                lineIndex++;
                break;
            case 6:
                SceneLoader.Instance.LoadScene("NormalHouse1", 1f);
                lineIndex++;
                break;
            case 7:
                AudioManager.Instance.ChangePitch(-1f);
                FlipBox(ballonSpriteFlipped);
                ChangeSprite(citizen, citizenSprites[6]);

                if (GameManager.Instance.objectWasFound)
                {
                    if (ObjectDatabase.objectInfo.TryGetValue(GameManager.Instance.hiddenObject, out var info))
                    {
                        ChangeSprite(detective, detectiveSprites[7]);
                        ShowDialogue("Hum... Looks like the thieves took your " + info.displayName + ".");
                    }
                }
                else
                {
                    ChangeSprite(detective, detectiveSprites[8]);
                    ShowDialogue("It seems there's nothing unusual. Maybe it was just your cat messing around while you were out.");
                }

                AnimateBox();
                lineIndex++;
                break;
            case 8:
                if (GameManager.Instance.objectWasFound)
                {
                    ChangeSprite(citizen, citizenSprites[2]);

                    switch (GameManager.Instance.hiddenObject)
                    {
                        case "ration":
                            ChangeSprite(detective, detectiveSprites[1]);
                            ShowDialogue("They must have a hungry cat.");
                            break;
                        case "book2":
                            ChangeSprite(detective, detectiveSprites[4]);
                            ShowDialogue("They really must love to read...");
                            break;
                        case "car":
                            ChangeSprite(detective, detectiveSprites[4]);
                            ShowDialogue("Was it a rare one?");
                            break;
                        case "cat":
                            ChangeSprite(detective, detectiveSprites[2]);
                            ShowDialogue("That's... Unfortunate. But no worries, we'll make sure he's ok.");
                            break;
                        case "food":
                            ChangeSprite(detective, detectiveSprites[0]);
                            ShowDialogue("They might be desperately hungry...");
                            break;
                        case "clock":
                            ChangeSprite(detective, detectiveSprites[4]);
                            ShowDialogue("They couldn't wait another second to get their hands on this, huh...?");
                            break;
                        case "poster":
                            ChangeSprite(detective, detectiveSprites[4]);
                            ShowDialogue("They're either 13 or just really stuck in time.");
                            break;
                        case "fish":
                            ChangeSprite(detective, detectiveSprites[3]);
                            ShowDialogue("Let's hope the little guy is still alive by now...");
                            break;
                        case "jewelry":
                            ChangeSprite(detective, detectiveSprites[4]);
                            ShowDialogue("They're probably hoping it is not a fake one, haha...");
                            break;
                        case "magnet":
                            ChangeSprite(detective, detectiveSprites[0]);
                            ShowDialogue("I don't get why barge into a home to rob that but ok.");
                            break;
                        case "mug":
                            ChangeSprite(detective, detectiveSprites[4]);
                            ShowDialogue("I guess Michael Scott didn't like another #1 boss, haha...");
                            break;
                        case "pan":
                            ChangeSprite(detective, detectiveSprites[4]);
                            ShowDialogue("Whoa. They might be cooking something...");
                            break;
                        case "penguim":
                            ChangeSprite(detective, detectiveSprites[1]);
                            ShowDialogue("Why would someone klep something like this...");
                            break;
                        case "phone":
                            ChangeSprite(detective, detectiveSprites[0]);
                            ShowDialogue("So... Where did you call us from?");
                            break;
                        case "plant":
                            ChangeSprite(detective, detectiveSprites[5]);
                            ShowDialogue("Must be a nature lover.");
                            break;
                        case "portrait":
                            ChangeSprite(detective, detectiveSprites[1]);
                            ShowDialogue("It has a photo of yours? Creepy guy.");
                            break;
                        case "radio":
                            ChangeSprite(detective, detectiveSprites[5]);
                            ShowDialogue("They're pretty old-fashioned huh.");
                            break;
                        case "rubik":
                            ChangeSprite(detective, detectiveSprites[4]);
                            ShowDialogue("Your house might have been invaded by a nerd. Heh.");
                            break;
                        case "sheet":
                            ChangeSprite(detective, detectiveSprites[5]);
                            ShowDialogue("Maybe it was a kid trying to disguise as a ghost?");
                            break;
                        case "watch":
                            ChangeSprite(detective, detectiveSprites[0]);
                            ShowDialogue("Makes sense, it is an expensive item.");
                            break;
                    }
                }
                else
                {
                    FlipBox(ballonSprite);
                    ChangeSprite(citizen, citizenSprites[1]);
                    ChangeSprite(detective, detectiveSprites[1]);
                    ShowDialogue("... You're a bad detective...");
                }

                AnimateBox();
                lineIndex++;
                break;
            case 9:
                if (GameManager.Instance.objectWasFound)
                {
                    FlipBox(ballonSpriteFlipped);
                    ChangeSprite(detective, detectiveSprites[7]);
                    ShowDialogue("Anyways, we'll start our investigation right now and catch whoever did this.");
                    AnimateBox();
                    lineIndex++;
                }
                else
                {
                    SceneLoader.Instance.LoadScene("GameOver", 1f);
                    AudioManager.Instance.FadeVolume(true);
                }

                break;
            case 10:
                SceneLoader.Instance.LoadScene("TheEnd", 1f);
                AudioManager.Instance.ChangePitch(1f);
                AudioManager.Instance.FadeVolume(true);
                break;
        }
    }

    private void FlipBox(Sprite boxSprite)
    {
        dialogueBox.GetComponent<Image>().sprite = boxSprite;
    }

    private void AnimateBox()
    {
        dialogueBox.GetComponent<Animator>().SetTrigger("Next");
    }

    private void ChangeSprite(GameObject character, Sprite sprite)
    {
        character.GetComponent<Image>().sprite = sprite;
        character.GetComponent<Animator>().SetTrigger("Bounce");
    }
}
