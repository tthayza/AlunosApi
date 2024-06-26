﻿using System.ComponentModel.DataAnnotations;

namespace AlunosApi.Models
{

    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Idade { get; set; }
    }
}
