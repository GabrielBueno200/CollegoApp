import { AxiosError } from 'axios';
import { default as api } from '../endpoints';
import { UserActions, UserTypes } from '..';
import { IUserError } from '../default/defaultTypes';
import { ITokens } from '../../../../../models/token/token';
import { requestingUser, failedRequestingUser } from '../default/defaultActions';
import { dispatch, AsyncAction  } from '../../../..';





/**
 *  Action body 
 */
const userLogoutAction = (): UserActions => ({
    type: UserTypes.USER_EXIT_SUCCESS,
});


export const signOutAsync = (tokens: ITokens):AsyncAction  => async dispatch => {

    try {
        
        dispatch(requestingUser());

        await api.logout(tokens);

        dispatch(userLogoutAction());

    }

    catch(ex){

        const error = (ex as AxiosError<IUserError>).response!.data;
        
        dispatch(failedRequestingUser(error));
    }

};


export default (tokens:ITokens) => dispatch(signOutAsync(tokens));
