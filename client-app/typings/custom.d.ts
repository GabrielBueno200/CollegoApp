import { AppState } from "../app/store";

declare module 'redux-thunk-dispatcher'{
    type Dispatch<S> = ThunkDispatch<AppState, void, n>
};