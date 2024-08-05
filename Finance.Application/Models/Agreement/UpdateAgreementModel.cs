using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Models.Agreement
{
    public class UpdateAgreementModel
    {
        /// <summary>
        /// Anlaşma başlığı
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Anlaşma İçeriği
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// Anlaşmanın Başlama Tarihi
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Anlaşmanın Bitiş Tarihi
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Anlaşmanın Anahtar Kelimeleri
        /// </summary>
        public string? Keywords { get; set; }
    }
}
