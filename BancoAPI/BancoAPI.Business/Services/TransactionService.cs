using BancoAPI.Data.Entities;
using BancoAPI.Data.Factories;
using BancoAPI.Data.Models;
using BancoAPI.Data.Repository;

namespace BancoAPI.Business.Services
{
    public interface ITransactionService
    {
        List<TransactionDTO> GetTransactionsByUserId(string userId);
        bool AddTransaction(TransactionDTO transationDTO);
        bool EditTransaction(TransactionDTO transactionDTO);
        bool deleteTransaction(int Id, TrasactionType type);
    }
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<TransactionEntity> _transactionsRepository;
        private readonly IGenericRepository<AccountEntity> _accountRepository;
        private readonly IDTOFactory _dtoFactory;

        public TransactionService(IGenericRepository<TransactionEntity> transactionsRepository, IGenericRepository<AccountEntity> accountRepository, IDTOFactory dtoFactory)
        {
            _transactionsRepository = transactionsRepository;
            _dtoFactory = dtoFactory;
            _accountRepository = accountRepository;
        }

        public List<TransactionDTO> GetTransactionsByUserId(string userId)
        {
            //Get user account
            var transactions = _transactionsRepository.FindByUserId(userId);

            //Convert Entity to Dto
            return _dtoFactory.GetTransactionsDTO(transactions);

        }

        public bool AddTransaction(TransactionDTO transationDTO)
        {
            try
            {
                var verifyAccount = _accountRepository.FindByUserId(transationDTO.userId).FirstOrDefault();
                //Verificar se userid existe
                if (verifyAccount == null)
                {
                    //create account com userid
                    var newAccount = new AccountEntity()
                    {
                        userId = transationDTO.userId,
                        created = transationDTO.Created,
                        updated = transationDTO.Updated,
                        username = transationDTO.userId,
                        income = 0,
                        expense = 0
                    };
                    if (transationDTO.type == TrasactionType.Income)
                        newAccount.income += transationDTO.value;
                    else
                        newAccount.expense += transationDTO.value;

                    _accountRepository.Add(newAccount);
                    _accountRepository.Save();
                }
                else
                {
                    if (transationDTO.type == TrasactionType.Income)
                        verifyAccount.income += transationDTO.value;
                    else
                        verifyAccount.expense += transationDTO.value;

                    _accountRepository.Update(verifyAccount);
                    _accountRepository.Save();
                }
                //Convert dto to entity
                var transactionEntity = new TransactionEntity();
                transactionEntity = _dtoFactory.UpdateTransactionEntity(transationDTO, transactionEntity);
                //Add to database
                _transactionsRepository.Add(transactionEntity);
                _transactionsRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditTransaction(TransactionDTO transactionDTO)
        {
            var t = _transactionsRepository.Find(transactionDTO.id);
            if (t == null)
            {
                return false;
            }
            else
            {
                var account = _accountRepository.FindByUserId(transactionDTO.userId).FirstOrDefault();
                if (t.type == TrasactionType.Income)
                    account.income += (transactionDTO.value - t.value);
                else
                    account.expense += (transactionDTO.value - t.value);
                _accountRepository.Update(account);
                _accountRepository.Save();
                t = _dtoFactory.UpdateTransactionEntity(transactionDTO, t);
                _transactionsRepository.Update(t);
                _transactionsRepository.Save();

                //var mudar= new TransactionEntity();
                //mudar=  _dtoFactory.UpdateTransactionEntity(transactionDTO, mudar);
                //_transactionsRepository.Update(mudar);

                //_transactionsRepository.Save();
            }
            return true;
        }

        public bool deleteTransaction(int Id, TrasactionType type)
        {
            var t = _transactionsRepository.Find(Id);
            var account = _accountRepository.FindByUserId(t.userId).FirstOrDefault();

            if (t.type == TrasactionType.Income)
                account.income -= t.value;
            else
                account.expense -= t.value;
            _accountRepository.Update(account);
            _transactionsRepository.Delete(t);
            //Save changes
            _transactionsRepository.Save();
            return true;
        }

        //AUTO MAPPER
        public List<TransactionDTO> mapperGetTransactionsByUserId(string userId)
        {
            //Get user account
            var transactions = _transactionsRepository.FindByUserId(userId);

            //Convert Entity to Dto
            return _dtoFactory.GetTransactionsDTO(transactions);

        }
    }
}
