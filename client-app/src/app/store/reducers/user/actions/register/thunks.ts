import { AxiosError } from 'axios';
import { Dispatch } from 'redux';
import { IUser } from '../../../../../models/users/user';
import { requestingUser, failedRequestingUser } from '../default/defaultActions';
import { default as api } from '../endpoints';
import { UserActions, UserTypes } from '..';
import { IUserError } from '../default/defaultTypes';
import { IUserRegister } from '../../../../../models/users/register';


/**
 *  Action body 
 */
const userRegisterAction = (): UserActions => ({
    type: UserTypes.USER_REGISTERED_SUCCESS
});


export const signUpAsync = (data: IUserRegister) => async (dispatch: Dispatch<UserActions>) => {

    try {
        
        dispatch(requestingUser());

        await api.signUp(data);

        dispatch(userRegisterAction());

    }

    catch(ex){

        const error = (ex as AxiosError<IUserError>).response!.data;
        
        dispatch(failedRequestingUser(error))
    }

}
