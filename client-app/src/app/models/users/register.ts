export interface IUserRegister {
    userName: string;
    fullName: string;
    email: string;
    password: string;
    confirmPassword: string;
    university: string;
    courseId: string;
    notListedCourse?: string;
    termsAccepted: boolean;
    profileThumbnail?: BinaryType;
}