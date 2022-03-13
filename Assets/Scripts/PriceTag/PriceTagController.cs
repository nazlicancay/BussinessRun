    using System;
    using System.Collections;
using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;

    public class PriceTagController : MonoBehaviour
    {
        [SerializeField] private Sprite Redimage;
        [SerializeField] private Sprite Greenimage;
        private List<PriceTag> priceTags = new List<PriceTag>();
        [SerializeField] public float Score;

        private void Start  ()
        {
            //updatePriceTaglist();
        }

        private void Update()
        {
            updatePriceTaglist();

            Score = ScoreManager.Instance.GameScore;
            foreach (var priceTag in priceTags)
            {
                float price = priceTag.price;
                ChangePriceTags(Score,priceTag);
            }   
        }

        private void ChangePriceTags(float score, PriceTag priceTag)
        {
            if (score < priceTag.price)
            {
                priceTag.sr.sprite = Redimage;
            
            }
            else
            {
                priceTag.sr.sprite = Greenimage;
            }
        }

        // public void ChangePriceTags(float Score, PriceTag priceTag)
        // {
        //     {
        //         foreach (var priceTag in priceTags)
        //         {
        //             int price = Int32.Parse(priceTag.text.text);
        //
        //             if (Score < price)
        //             {
        //                 priceTag.sr.sprite = Redimage;
        //
        //             }
        //             else
        //             {
        //                 priceTag.sr.sprite = Greenimage;
        //             }
        //
        //         }
        //     }
        // }

        public void updatePriceTaglist()
        {
            priceTags = GetComponentsInChildren<PriceTag>().ToList();

        }
    }
