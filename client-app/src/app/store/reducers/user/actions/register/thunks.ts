import { AxiosError } from 'axios';
import { requestingUser, failedRequestingUser } from '../default/defaultActions';
import { default as api } from '../endpoints';
import { UserActions, UserTypes } from '..';
import { IUserRegister } from '../../../../../models/users/register';
import { AsyncAction } from '../../../..';
import { IError } from '../../../../../models/errors/errors';


/**
 *  Action body 
 */
const userRegisterAction = (): UserActions => ({
    type: UserTypes.USER_REGISTERED_SUCCESS
});


export const signUpAsync = (data: IUserRegister):AsyncAction => async dispatch => {

    try {
        
        dispatch(requestingUser());
           await api.signUp(data);

        dispatch(userRegisterAction());

    }

    catch(ex){

        const error = (ex as AxiosError<IError>).response!.data;
        
        dispatch(failedRequestingUser(error))
    }

};

export default signUpAsync;