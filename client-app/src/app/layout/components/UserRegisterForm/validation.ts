import * as Yup from 'yup';

/**
 * Masks
 */
export const usernameFormat = (username: string) => 
    `${username.replace(' ', '')}`.replace(/[$-/:-?{-~!"^`\[\]]/, "").toLowerCase();

export const fullnameFormat = (name: string) =>
    name.split(' ')
    .map(x => 
        !["da", "do", "de", "Da", "Do", "De"]
        .some(v => v === x) ? x.charAt(0).toUpperCase() + x.slice(1).toLowerCase() : x.toLowerCase())
    .join(' ');

/**
 * Validation
 */
class ValidationConstants {

    static PASSWORD_REGEX = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$/;
    static PASSWORD_ERROR = "Deve conter 6 caracteres, um maiúsculo, um minúsculo, um numérico e um especial!";
    static PASS_DONT_MATCH_ERROR = "As senhas informadas não coincidem";
    static ACCEPT_TERMS_ERROR = "Você só poderá prosseguir se aceitar os termos de uso";

};

const schema = Yup.object({

    userName: Yup.string().trim().required(),

    fullName: Yup.string().trim().required(),

    email: Yup.string().email().required(),

    password: Yup.string().required().matches(
        ValidationConstants.PASSWORD_REGEX, 
        ValidationConstants.PASSWORD_ERROR 
    ),

    confirmPassword: Yup.string().required().oneOf(
        [Yup.ref('password')],
        ValidationConstants.PASS_DONT_MATCH_ERROR 
    ),

    university: Yup.string().trim().notRequired(),

    courseId: Yup.string().notRequired(),

    notListedCourse: Yup.string().notRequired(),

    profileThumbnail: Yup.mixed().notRequired(),

    termsAccepted: Yup.boolean().oneOf(
        [true],
        ValidationConstants.ACCEPT_TERMS_ERROR)
});

export default schema;