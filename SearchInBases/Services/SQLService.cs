using BasicSQLFormatter;
using SearchInBases.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchInBases.Services
{
    public static class SQLService
    {
        private static bool somente_consulta = Vars.somenteConsulta;

        private static List<string> palavras_proibidas = new ();

        private static List<string> palavras_obrigatorias = new();

        public static bool permitirExecutarComando(SQLParams sqlParams) 
        {
            Log.Add("Somente Consulta: " + somente_consulta +  "; Comando executado: " + sqlParams.sql);

            InicializarListas();

            if (somente_consulta)
            {
                return validarSQlSomenteConsulta(sqlParams);
            }

            return validarComandoSQL(sqlParams);
        }

        

        private static bool validarComandoSQL(SQLParams sqlParams)
        {
            // Permissão para alter, drop e delete não implementado ainda
            return false;
        }

        private static bool validarSQlSomenteConsulta(SQLParams sqlParams)
        {
            bool sqlValido = true;
            string sql = sqlParams.sql.ToUpper();
            
            foreach(var proibido in palavras_proibidas)
            {
                if (sql.Contains(proibido.ToUpper()))
                {
                    Log.Add("Palavra proibida localizada: " + proibido);
                    sqlValido = false;
                }
                    
            }

            return sqlValido;
        }

        private static void InicializarListas()
        {
            InicializarListaPalavrasProibidas();
            InicializarListaPalavrasObrigatorias();
        }

      

        private static void InicializarListaPalavrasProibidas()
        {
            palavras_proibidas.Clear();
            palavras_proibidas.Add("drop ");
            palavras_proibidas.Add("create ");
            palavras_proibidas.Add("alter ");
            palavras_proibidas.Add("delete ");
            palavras_proibidas.Add("insert ");
            palavras_proibidas.Add("add ");
            palavras_proibidas.Add("remove ");
            palavras_proibidas.Add("commit");
            palavras_proibidas.Add("rollback");
            palavras_proibidas.Add("kill ");
            palavras_proibidas.Add("database ");
            palavras_proibidas.Add("execute ");
            
        }

        private static void InicializarListaPalavrasObrigatorias()
        {
            palavras_obrigatorias.Add("select");
            palavras_obrigatorias.Add("from");                       
        }

        public static bool SQLValido(SQLParams sqlParams)
        {
            bool sqlValido = true;

            string sql = sqlParams.sql.ToUpper();

            foreach (var obrigatoria in palavras_obrigatorias)
            {
                if (!sql.Contains(obrigatoria.ToUpper()))
                {
                    Log.Add("Palavra obrigatório não localizada: " + obrigatoria);
                    sqlValido = false;
                }

            }

            return sqlValido;
        }

        public static string GetDescriptoCol(string nome, bool isWhere = false)
        {
            string key = Vars.keySQL;
            if (String.IsNullOrEmpty(key))
                return nome;

            string alias = nome;
            if (alias.Contains("."))          
                alias = alias.Substring(alias.IndexOf(".") + 1);          
            alias = $"as {alias}";

            return $"CONVERT(AES_DECRYPT(unhex({nome}), '{key}'), char(1000)) {(!isWhere ? alias : "")}";
        }

        public static string Formatar(string sql)
        {
            return new SQLFormatter(sql).Format().Trim();
        }

        public static string TratarParamCamposCripto(string sql)
        {
            bool existeCampoCripto = GetExisteCampoCripto(sql);

            while (existeCampoCripto)
            {
                var idxIni = sql.IndexOf("[");
                var idxFim = sql.IndexOf("]") + 1;
                string campoCript = sql.Substring(idxIni, idxFim - idxIni).Replace("[", "").Replace("]", "");

                bool isWhere = campoCript.Substring(campoCript.Length - 1, 1).Contains(":");

                if (isWhere) campoCript = campoCript.Replace(":", "");
                
                string campoDescrip = SQLService.GetDescriptoCol(campoCript, isWhere);

                sql = sql.Replace("[" + campoCript + (isWhere ? ":" : "") + "]", campoDescrip);
                existeCampoCripto = GetExisteCampoCripto(sql);
            }


            return sql;
        }

        private static bool GetExisteCampoCripto(string sql)
        {
            return sql.Contains("[") && sql.Contains("]");
        }
    }
}
