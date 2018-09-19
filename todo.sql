-- Procedures feitas:
-- Cliente         -> CRUD/E
-- Endereco        -> E
-- Cargo           -> CRUD/E
-- Funcionario     -> CRUD/E
-- Estabelecimento -> CRUD/E
-- Usuario         -> CRUD/ spuSenha
-- Horário         -> CRUD
-- Agendamento     -> CRD

/// <summary>
        /// Metodo responsavel pela criptografia SHA1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string SHA1Crypto(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            SHA1 sha = new SHA1CryptoServiceProvider();
            var hashedData = sha.ComputeHash(Encoding.Unicode.GetBytes(value));
            var sha1text = string.Empty;

            foreach (var b in hashedData)
            {
                sha1text += string.Format("{0,2:X2}", b);
            }

            return sha1text;
        }

		
		https://www.codeproject.com/Articles/1216929/asp-net-core-identity-user-management-mvc