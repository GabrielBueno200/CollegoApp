import { AppState } from "../app/store";

declare global {
    interface Window {
        __REDUX_DEVTOOLS_EXTENSION_COMPOSE__?: typeof compose;
    }
}

declare module 'redux-thunk-dispatcher'{
    type Dispatch<S> = ThunkDispatch<AppState, void, n>
};