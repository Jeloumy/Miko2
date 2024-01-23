using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManagement : MonoBehaviour
{
    public Animator playerAnimator; // Référence à l'Animator du joueur
    public GameObject[] skins; // Tableau des skins (préfabriqués), y compris ceux animés

    public void ChangeSkin(int skinIndex)
    {
        if (skinIndex >= 0 && skinIndex < skins.Length)
        {
            // Désactiver tous les skins
            foreach (var skin in skins)
            {
                skin.SetActive(false);
            }

            // Activer le skin sélectionné
            skins[skinIndex].SetActive(true);

            // Si le skin a un Animator, le configurer
            Animator skinAnimator = skins[skinIndex].GetComponent<Animator>();
            if (skinAnimator != null)
            {
                playerAnimator.runtimeAnimatorController = skinAnimator.runtimeAnimatorController;
            }
        }
    }
}
