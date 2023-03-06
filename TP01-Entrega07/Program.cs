//Faça as seguintes tarefas:

//Escreva testes unitários para as seguintes funcionalidades do aplicativo:

//Adicionar contato
//Listar contatos
//Atualizar contato
//Remover contato
//Cada funcionalidade deve ter pelo menos um teste para um cenário válido e
//um teste para um cenário inválido.

//Por exemplo, para a funcionalidade "Adicionar contato", pode-se ter os
//seguintes testes:

//TestAddValidContact: testa a adição de um contato válido.
//TestAddInvalidContact: testa a resposta do programa a um contato inválido,
//quando o usuário insere informações inválidas.
//TestAddDuplicateContact: testa a resposta do programa a um contato duplicado,
//quando o usuário tenta adicionar um contato com um nome que já existe na lista.

var contactService = new TP01_Entrega07.ContactService();
Console.WriteLine("testrun");

namespace TP01_Entrega07 { 
    public class Contact {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string name, string phone, string email) {
            Name = name;
            Phone = phone;
            Email = email;
        }
    }

    public class ContactService {
        public List<Contact> contacts = new List<Contact>();

        public bool AddContact(string name, string phone, string email) {
            var contact = new Contact(name, phone, email);
            contacts.Add(contact);

            return true;
        }

        public string ListContacts() {
            if (contacts.Count == 0) {
                return "Não há contatos cadastrados.";
            }

            var contatos = "Lista de contatos:\n";

            for (int i = 0; i < contacts.Count; i++) {
                var contact = contacts[i];
                contatos += $"{i + 1}. {contact.Name} - {contact.Phone} - {contact.Email}\n";
            }

            return contatos;
        }

        public string UpdateContact(int index, string name, string phone, string email) {
            if (index < 0 || index >= contacts.Count) {
                return "Índice inválido. Tente novamente.";
            }

            var contact = contacts[index];

            contact.Name = name;
            contact.Phone = phone;
            contact.Email = email;

            return $"Contato '{name}' atualizado com sucesso.";
        }

        public string RemoveContact(int index) {
            if (index < 0 || index >= contacts.Count) {
                return "Índice inválido. Tente novamente.";
            }

            var contact = contacts[index];
            contacts.Remove(contact);

            return $"Contato '{contact.Name}' removido com sucesso.";
        }
    }

}