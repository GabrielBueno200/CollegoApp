import { AxiosError } from 'axios';
import { requestingUser, failedRequestingUser, clearUserErrors } from '../default/defaultActions';
import { default as api } from '../endpoints';
import { UserActions, UserTypes } from '..';
import { IUserRegister } from '../../../../../models/users/register';
import { AsyncAction } from '../../../..';
import { IUser } from '../../../../../models/users/user';
import { ISuccess } from '../../../models/success';


/**
 *  Action body 
 */
const userRegisterAction = (user: IUser, successMessage: ISuccess): UserActions => ({
    type: UserTypes.USER_REGISTERED_SUCCESS,
    payload: { user, successMessage }
});


export const signUpAsync = (data: IUserRegister): AsyncAction => async dispatch => {

    try {
        
        dispatch(requestingUser());
        
        const user = await api.signUp(data);

        const successMessage: ISuccess = {
            title: "Cadastrado com sucesso!",
            body: `Seja bem-vindo ao Collego, ${user.fullName.split(' ')[0]}!`
        }; 

        console.log(successMessage)

        dispatch(userRegisterAction(user, successMessage));

        dispatch(clearUserErrors());

    }

    catch(ex){

        const error = (ex as AxiosError).response!.data;
        
        dispatch(failedRequestingUser(error))
    }

};

export default signUpAsync;