// -----------------------------------------------------------------------﻿------
// <copyright file="CipherViewModel.cs" company="NanoTaboada">
//   Copyright (c) 2013 Nano Taboada, http://openid.nanotaboada.com.ar 
// 
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//   of this software and associated documentation files (the "Software"), to deal
//   in the Software without restriction, including without limitation the rights
//   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the Software is
//   furnished to do so, subject to the following conditions:
// 
//   The above copyright notice and this permission notice shall be included in
//   all copies or substantial portions of the Software.
// 
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//   THE SOFTWARE.
// </copyright>
// -----------------------------------------------------------------------﻿------

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "For educational purposes only.")]

namespace Dotnet.Samples.Avalon
{
    using System;
    using System.ComponentModel;
    using System.Text.RegularExpressions;

    public class CipherViewModel : ViewModel, IDataErrorInfo
    {
        private readonly Cipher cipher;
        private EncryptCommand encrypt;
        private DecryptCommand decrypt;
        private bool isReadOnly;
        private bool isInputEnabled;
        private bool isOutputEnabled;

        public CipherViewModel()
        {
            this.cipher = new Cipher();

            this.encrypt = new EncryptCommand(this, this.DoEncrypt);
            this.decrypt = new DecryptCommand(this, this.DoDecrypt);

            this.IsInputEnabled = true;
            this.IsOutputEnabled = false;
        }

        public EncryptCommand Encrypt
        {
            get
            {
                return this.encrypt;
            }

            set
            {
                this.encrypt = value;
                this.OnPropertyChanged("Encrypt");
            }
        }

        public DecryptCommand Decrypt
        {
            get
            {
                return this.decrypt;
            }

            set
            {
                this.decrypt = value;
                this.OnPropertyChanged("Decrypt");
            }
        }

        public string Plaintext
        {
            get
            {
                return this.cipher.Plaintext;
            }

            set
            {
                this.cipher.Plaintext = value;
                this.OnPropertyChanged("Plaintext");
            }
        }

        public string Ciphertext
        {
            get
            {
                return this.cipher.Ciphertext;
            }

            set
            {
                this.cipher.Ciphertext = value;
                this.OnPropertyChanged("Ciphertext");
            }
        }

        public string Passphrase
        {
            get
            {
                return this.cipher.Passphrase;
            }

            set
            {
                this.cipher.Passphrase = value;
                this.OnPropertyChanged("Passphrase");
            }
        }

        public string Salt
        {
            get
            {
                return this.cipher.Salt;
            }

            set
            {
                this.cipher.Salt = value;
                this.OnPropertyChanged("Salt");
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this.isReadOnly;
            }

            set
            {
                this.isReadOnly = value;
                this.OnPropertyChanged("IsReadOnly");
            }
        }

        public bool IsInputEnabled
        {
            get
            {
                return this.isInputEnabled;
            }

            set
            {
                this.isInputEnabled = value;
                this.OnPropertyChanged("IsInputEnabled");
            }
        }

        public bool IsOutputEnabled
        {
            get
            {
                return this.isOutputEnabled;
            }

            set
            {
                this.isOutputEnabled = value;
                this.OnPropertyChanged("IsOutputEnabled");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case "Plaintext":
                        if (string.IsNullOrEmpty(this.Plaintext)
                            /* don't validate when in Decrypt mode. */
                            && !this.IsReadOnly)
                        {
                            error = "Plaintext value cannot be null or empty.";
                        }

                        break;

                    case "Ciphertext":
                        if (string.IsNullOrEmpty(this.Ciphertext)
                            /* don't validate when in Encrypt mode. */
                            && this.IsReadOnly)
                        {
                            error = "Ciphertext value cannot be null or empty.";
                        }

                        break;

                    case "Passphrase":
                        if (string.IsNullOrEmpty(this.Passphrase))
                        {
                            error = "Passphrase value cannot be null or empty.";
                        }

                        break;

                    case "Salt":
                        if (string.IsNullOrEmpty(this.Salt))
                        {
                            error = "Salt value cannot be null or empty.";
                        }
                        else if (this.Salt.Length < 8)
                        {
                            error = "Salt should be at least eight bytes long.";
                        }

                        break;
                }

                return error;
            }
        }

        private void DoEncrypt()
        {
            this.IsReadOnly = true;
            this.IsInputEnabled = false;
            this.IsOutputEnabled = true;
            this.Ciphertext = this.cipher.Encrypt();
            this.Plaintext = string.Empty;
        }

        private void DoDecrypt()
        {
            this.IsReadOnly = false;
            this.IsInputEnabled = true;
            this.IsOutputEnabled = false;
            this.Plaintext = this.cipher.Decrypt();
            this.Ciphertext = string.Empty;
        }
    }
}
