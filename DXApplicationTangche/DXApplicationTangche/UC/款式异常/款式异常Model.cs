using DXApplicationTangche.UC.门店下单.DTO;
using mendian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationTangche.UC.款式异常
{
    class 款式异常Model
    {
        List<版型Dto> 版型Dtos = new List<版型Dto>();  //  版型
        private List<款式图片一览Dto> 款式图片一览Dtos = new List<款式图片一览Dto>();

        //  展示视图
        private List<款式图片一览Dto> views = new List<款式图片一览Dto>();
        //  服装种类
        private List<String> list服装种类 = new List<string>();
        //  年份
        private List<String> list年份 = new List<string>();

        public List<款式图片一览Dto> Views { get => views; set => views = value; }
        public List<string> List服装种类 { get => list服装种类; set => list服装种类 = value; }
        public List<string> List年份 { get => list年份; set => list年份 = value; }

        public 款式异常Model(
            List<款式图片一览Dto> 款式图片一览Dtos
            , List<版型Dto> 版型Dtos
            ) {
            this.款式图片一览Dtos = 款式图片一览Dtos;
            this.版型Dtos = 版型Dtos;
        }

        public 款式异常Model initData() {
            this.views.AddRange(this.款式图片一览Dtos);
            foreach (款式图片一览Dto dto in this.款式图片一览Dtos)
            {
                if (!this.List服装种类.Contains(dto.STYLE_PUBLISH_CATEGORY_CD))
                {
                    this.List服装种类.Add(dto.STYLE_PUBLISH_CATEGORY_CD);
                }
                if (!this.List年份.Contains(dto.SYTLE_YEAR))
                {
                    this.List年份.Add(dto.SYTLE_YEAR);
                }
            }

            if (List年份.Count > 0 && List服装种类.Count > 0)
            {
                this.build款式异常Model(List年份[0], List服装种类[0]);
            }
            return this;
        }

        public 款式异常Model build款式异常Model(String 年份, String 服装种类) {
            this.Views.Clear();
            List<款式图片一览Dto> dtos = new List<款式图片一览Dto>();
            foreach (款式图片一览Dto dto in this.款式图片一览Dtos)
            {
                if (dto.SYTLE_YEAR.Equals(年份) && dto.STYLE_PUBLISH_CATEGORY_CD.Equals(服装种类))
                {
                    dtos.Add(dto);
                }
            }
            this.Views = dtos;
            return this;
        }

    }
}
