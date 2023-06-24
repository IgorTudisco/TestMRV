using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestMRV.Data;
using TestMRV.Data.Dtos;
using TestMRV.Models;

namespace TestMRV.Service
{
    public class CardService
    {
        private CardContext _context;
        private IMapper _mapper;

        public CardService(CardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void SaveCard()
        {
            _context.SaveChanges();
        }

        public Card AddCard(CreateCardDTO cardDTO)
        {
            Card card = _mapper.Map<Card>(cardDTO);
            if (card.Price > 500)
            {
                card.Price = card.Price - (card.Price * 10 / 100);
            }
            _context.Cards.Add(card);
            SaveCard();
            return card;
        }

        public IEnumerable<ReadCardDTO> GetCards(int skip = 0, int take = 10)
        {
            return _mapper.Map<List<ReadCardDTO>>(_context.Cards.Skip(skip).Take(take));
        }

        public Card? CardReturn(int id)
        {
            var card = _context.Cards.FirstOrDefault(card => card.CardId == id);
            return card;
        }

        public ReadCardDTO? GetCardById(int id)
        {
            var card = CardReturn(id);
            if (card == null) return null;
            var cardDTO = _mapper.Map<ReadCardDTO>(card);
            return cardDTO;
        }

        public Card? PutCard(int id, UpdateCardDTO cardDTO)
        {
            var card = CardReturn(id);
            if (card == null) return null;
            var updateCard = _mapper.Map(cardDTO, card);
            SaveCard();
            return updateCard;
        }

        public UpdateCardDTO? PatchCard(int id)
        {
            var card = CardReturn(id);
            if (card == null) return null;

            var cardUpdate = _mapper.Map<UpdateCardDTO>(card);
            return cardUpdate;
        }

        public void PatchCardSave(UpdateCardDTO cardUpdate, int id)
        {
            var card = CardReturn(id);
            _mapper.Map(cardUpdate, card);
            SaveCard();
        }

        public int? DeleteCard(int id)
        {
            var card = CardReturn(id);
            if (card == null) return null;
            _context.Remove(card);
            SaveCard();
            return id;
        }

    }
}
