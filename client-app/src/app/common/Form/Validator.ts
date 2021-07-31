import * as Yup from 'yup';

Yup.setLocale({
  mixed: {
    required: 'Preencha esse campo para prosseguir'
  },
  string: {
    email: 'Insira um endereço de e-mail válido',
    min: 'Valor muito curto (mínimo ${min} caracteres)',
    max: 'Valor muito longo (máximo ${max} caracteres)',
  },
  number: {
    min: 'Valor inválido (deve ser maior ou igual a ${min})',
    max: 'Valor inválido (deve ser menor ou igual a ${max})'
  }
});