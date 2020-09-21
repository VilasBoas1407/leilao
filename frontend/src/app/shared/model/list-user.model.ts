export class ListUserResponse{
    valid: boolean;
    lstUser : [
        UserData : {
            TB_LEILAO : any;
            ID_USUARIO : number;
            DS_USUARIO : string;
            DS_SENHA : string;
            FL_ATIVO : boolean;
            TOKEN : string;
        }
    ];

}