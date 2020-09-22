export class ListLeilaoResponse{
    valid : boolean;
    lstLeilao : [
        {
            ID_LEILAO: number;
            DS_NOME_LEILAO : string;
            VL_INICIAL: number;
            FL_PRODUTO_USADO : boolean;
            ID_USUARIO_RESPONSAVEL : number;
            DT_ABERTURA : Date;
            DT_FINALIZACAO : Date;
            TB_USUARIO : any
        }
    ]

}