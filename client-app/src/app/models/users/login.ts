export interface IUserLogin {
    userName: string | null;
    email: string | null;
    password: string;
};

export const EmptyUserLoginObject : IUserLogin = {
    userName: "",
    email: "",
    password: ""
};
