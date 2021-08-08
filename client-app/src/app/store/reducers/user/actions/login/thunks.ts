import { AxiosError } from 'axios';
import { Dispatch } from 'redux';
import { IUser } from '../../../../../models/users/user';
import { requestingUser, failedRequestingUser } from '../default/defaultActions';
import { default as api } from '../endpoints';
import { UserActions, UserTypes } from '..';
import { IUserLogin } from '../../../../../models/users/login';
import { AsyncAction } from '../../../..';
import { storeTokens } from '../../../../../services/user/login';


/**
 *  Action body 
 */
const userLoginAction = (user: IUser): UserActions => ({
    type: UserTypes.USER_LOGGEDIN_SUCCESS,
    payload: user
});


const signInAsync = (data: IUserLogin): AsyncAction => async dispatch => {

    try {
        
        dispatch(requestingUser());

        const auth = await api.signIn(data);

        storeTokens(auth.tokens);

        dispatch(userLoginAction(auth.user));

    }

    catch(ex){

        const error = (ex as AxiosError).response!.data;
        
        dispatch(failedRequestingUser(error))
    }

}

export default signInAsync;