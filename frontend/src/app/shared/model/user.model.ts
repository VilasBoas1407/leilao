export class UserResponse{
    valid: boolean;
    UserData : {
        TB_LEILAO : any;
        ID_USUARIO : number;
        DS_USUARIO : string;
        DS_SENHA : string;
        FL_ATIVO : boolean;
        TOKEN : string;
    }
    message: string;
}