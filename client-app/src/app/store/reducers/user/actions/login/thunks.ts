import { AxiosError } from 'axios';
import { Dispatch } from 'redux';
import { IUser } from '../../../../../models/users/user';
import { requestingUser, failedRequestingUser } from '../default/defaultActions';
import { default as api } from '../endpoints';
import { UserActions, UserTypes } from '..';
import { IUserLogin } from '../../../../../models/users/login';
import { IError } from '../../../../../models/errors/errors';


/**
 *  Action body 
 */
const userLoginAction = (user: IUser): UserActions => ({
    type: UserTypes.USER_LOGGEDIN_SUCCESS,
    payload: user
});


const signInAsync = (data: IUserLogin) => async (dispatch: Dispatch<UserActions>) => {

    try {
        
        dispatch(requestingUser());

        const user: IUser = await api.signIn(data);

        dispatch(userLoginAction(user));

    }

    catch(ex){

        const error = (ex as AxiosError<IError>).response!.data;
        
        dispatch(failedRequestingUser(error))
    }

}
