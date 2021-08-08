import * as Yup from 'yup';

const schema = Yup.object({

    userName: Yup.string().trim().required(),

    password: Yup.string().required()

});

export default schema;