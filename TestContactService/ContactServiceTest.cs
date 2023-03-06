using TP01_Entrega07;
namespace TestContactService {
    public class ContactServiceTest {
        [Theory]
        [InlineData("nome", "phone", "email@email2.ru")]
        [InlineData("nome1", "blabla", "email@email.ru")]
        public void TestAddValidContact(string name, string phone, string email) {
            //Arrange
            var contactService = new ContactService();

            //Act 
            var result = contactService.AddContact(name, phone, email);

            //Assert
            Assert.True(result);
        }


        [Theory]
        [InlineData("nome", "no numbers", "fakeemail")]
        [InlineData("nome1", "numbers", "fakeemail@noat")]
        public void TestAddInvalidContact(string name, string phone, string email) {
            //Arrange
            var contactService = new ContactService();

            //Act 
            var result = contactService.AddContact(name, phone, email);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Nome1", "Fone1", "Email1", "Nome2", "Fone2", "Email2",
            "Lista de contatos:\n1. Nome1 - Fone1 - Email1\n2. Nome2 - Fone2 - Email2\n")]
        public void TestValidListContacts(string name1, string phone1, string email1, string name2, string phone2, string email2, string result) {
            //Arrange
            var contactService = new ContactService();

            //Act
            contactService.AddContact(name1, phone1, email1);
            contactService.AddContact(name2, phone2, email2);
            var resultResult = contactService.ListContacts();

            //Assert
            Assert.Equal(result, resultResult);
        }

        [Theory]
        [InlineData("Nome1", "Fone1", "Email1", "Nome2", "Fone2", "Email2",
            "Não há contatos cadastrados.")]
        public void TestInvalidListContacts(string name1, string phone1, string email1, string name2, string phone2, string email2, string result) {
            //Arrange
            var contactService = new ContactService();

            //Act
            //contactService.AddContact(name1, phone1, email1);
            //contactService.AddContact(name2, phone2, email2);
            var resultResult = contactService.ListContacts();

            //Assert
            Assert.Equal(result, resultResult);
        }


        [Theory]
        [InlineData("Nome1", "Fone1", "Email1", "Nome2", "Fone2", "Email2",
            $"Contato 'Nome2' atualizado com sucesso.")]
        public void TestValidUpdateContact(string name1, string phone1, string email1, string name2, string phone2, string email2, string result) {
            //Arrange
            var contactService = new ContactService();

            //Act
            contactService.AddContact(name1, phone1, email1);            
            var resultResult = contactService.UpdateContact(0, name2, phone2, email2);

            //Assert
            Assert.Equal(result, resultResult);
        }

        [Theory]
        [InlineData("Nome1", "Fone1", "Email1", "Nome2", "Fone2", "Email2",
            "Índice inválido. Tente novamente.")]
        public void TestInvalidUpdateContact(string name1, string phone1, string email1, string name2, 
            string phone2, string email2, string result) {
            //Arrange
            var contactService = new ContactService();

            //Act
            contactService.AddContact(name1, phone1, email1);            
            var resultResult = contactService.UpdateContact(1, name2, phone2, email2);

            //Assert
            Assert.Equal(result, resultResult);
        }


        [Theory]
        [InlineData("Nome1", "Fone1", "Email1",
            "Contato 'Nome1' removido com sucesso.")]
        public void TestValidRemoveContact(string name1, string phone1, string email1, string result) {
            //Arrange
            var contactService = new ContactService();

            //Act
            contactService.AddContact(name1, phone1, email1);
            var resultResult = contactService.RemoveContact(0);

            //Assert
            Assert.Equal(result, resultResult);
        }

        [Theory]
        [InlineData("Nome1", "Fone1", "Email1",
            "Índice inválido. Tente novamente.")]
        public void TestInvalidRemoveContact(string name1, string phone1, string email1, string result) {
            //Arrange
            var contactService = new ContactService();

            //Act
            contactService.AddContact(name1, phone1, email1);
            var resultResult = contactService.RemoveContact(2);

            //Assert
            Assert.Equal(result, resultResult);
        }


    }

}