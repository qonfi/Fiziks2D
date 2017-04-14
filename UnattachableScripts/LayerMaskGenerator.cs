﻿

using UnityEngine;


namespace Fiziks2D
{

    /// <summary>
    /// 与えられた情報からレイヤーマスクを作る。ビット操作。
    /// </summary>
    public static class LayerMaskGenerator
    {
        #region
        // こんなふうに使う。
        // Physics.Raycast(Ray ray ~略~  int layerMask);
        // layerMask が ゼロのときは すべてのレイヤーと衝突しない。(つまりすべて false)
        #endregion


         public enum Ignore { SpecifiedLayer, ExceptSpecifiedLayer}


         /// <summary>
         /// レイヤーマスクを生成する。指定したレイヤーを無視、または指定したレイヤー以外を無視する。
         /// </summary>
         /// <param name="ignoreLayer"></param>
         /// <param name="specifiedLayerIndexes"></param>
        public static int Generate(Ignore ignoreLayer ,int[] specifiedLayerIndexes)
        {
            // 0 だとすべてのレイヤーと衝突しない。
            int layerMask = 0;
            
            // マスクに穴を開けていく。
            foreach(int element in specifiedLayerIndexes)
            {
                // 1(つまり一桁目がtrue)をindex桁シフトすることで、index桁にtrueを入れる。
                int flag = 1 << element;
                // or演算子 
                layerMask = layerMask | flag;
            }

            // 指定レイヤーを無視したい場合、生成したビットマスクを反転させる。
            if (ignoreLayer == Ignore.SpecifiedLayer) { layerMask = ~layerMask; }

            return layerMask;
        }
    }



}