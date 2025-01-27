using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using GwiNews.Application.DTOs;
using GwiNews.Application.DTOs.News;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class FirestoreToSqlServerDataStreamingService : IFirestoreToSqlServerDataStreamingService
    {
        private readonly IUserWithNewsRepository _userWithNewsRepository;
        private readonly INewsRepository _newsRepository;
        private readonly INewsCategoryRepository _newsCategoryRepository;
        private readonly INewsSubcategoryRepository _newsSubcategoryRepository;
        private readonly IReaderUserRepository _readerUserRepository;
        private readonly IProfessionalInformationRepository _professionalInformationRepository;
        private readonly IProfessionalSkillRepository _professionalSkillRepository;
        private readonly IFormationRepository _formationRepository;
        private readonly IMapper _mapper;
        private readonly FirestoreDb _firestoreDb;
        public FirestoreToSqlServerDataStreamingService(IUserWithNewsRepository userWithNewsRepository, INewsRepository newsRepository, INewsCategoryRepository newsCategoryRepository, INewsSubcategoryRepository newsSubcategoryRepository, IReaderUserRepository readerUserRepository, IProfessionalInformationRepository professionalInformationRepository, IProfessionalSkillRepository professionalSkillRepository, IFormationRepository formationRepository, IMapper mapper)
        {
            _userWithNewsRepository = userWithNewsRepository;
            _newsRepository = newsRepository;
            _newsCategoryRepository = newsCategoryRepository;
            _newsSubcategoryRepository = newsSubcategoryRepository;
            _readerUserRepository = readerUserRepository;
            _professionalInformationRepository = professionalInformationRepository;
            _professionalSkillRepository = professionalSkillRepository;
            _formationRepository = formationRepository;
            _mapper = mapper;
            GoogleCredential credential = GoogleCredential.FromJson(Environment.GetEnvironmentVariable("GWINEWS_FIRESTORE_API_KEY"));
            FirestoreClientBuilder builder = new FirestoreClientBuilder
            {
                Credential = credential
            };
            _firestoreDb = FirestoreDb.Create("gwinews-teste", builder.Build());
        }

        public async Task<ResponseModelDTO<bool>> DataStreamingCaller()
        {
            ResponseModelDTO<bool> response = new ResponseModelDTO<bool>();
            try
            {
                response = await UserWithNewsDataStreaming();
                response = await NewsCategoryDataStreaming();
                response = await NewsSubcategoryDataStreaming();
                response = await ReaderUserDataStreaming();
                response = await ProfessionalInformationDataStreaming();
                response = await ProfessionalSkillNewsDataStreaming();
                response = await FormationNewsDataStreaming();

                response.Message = "Streaming de Dados Realizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<bool>> UserWithNewsDataStreaming()
        {
            ResponseModelDTO<bool> response = new ResponseModelDTO<bool>();
            try
            {
                var usersWithNewsSql = await _userWithNewsRepository.GetUsersWithNews();

                var collection = _firestoreDb.Collection("UsersWithNews");
                var snapshot = await collection.GetSnapshotAsync();
                for (int i = 0; i < snapshot.Count; i++)
                {
                    Guid id = Guid.Parse(snapshot[i].Id);
                    UserRole userRole = (UserRole)snapshot[i].GetValue<int>("Role");
                    string completeName = snapshot[i].GetValue<string>("CompleteName");
                    string email = snapshot[i].GetValue<string>("Email");
                    string password = snapshot[i].GetValue<string>("Password");
                    bool status = snapshot[i].GetValue<bool>("Status");
                    UserWithNews userWithNews = new UserWithNews
                    {
                        Id = id,
                        Role = userRole,
                        CompleteName = completeName,
                        Email = email,
                        Password = password,
                        Status = status
                    };
                    if (usersWithNewsSql.Any(u => u.Id == userWithNews.Id))
                    {
                        await _userWithNewsRepository.UpdateUserWithNews(userWithNews);
                    }
                    else
                    {
                        await _userWithNewsRepository.CreateUserWithNews(userWithNews);
                    }
                }

                response.Data = true;
                response.Message = "Streaming de Dados de Usuários com Notícias Realizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<bool>> NewsCategoryDataStreaming()
        {
            ResponseModelDTO<bool> response = new ResponseModelDTO<bool>();
            try
            {
                var newsCategoriesSql = await _newsCategoryRepository.GetNewsCategories();

                var collection = _firestoreDb.Collection("NewsCategories");
                var snapshot = await collection.GetSnapshotAsync();
                for (int i = 0; i < snapshot.Count; i++)
                {
                    Guid id = Guid.Parse(snapshot[i].Id);
                    string name = snapshot[i].GetValue<string>("Name");
                    bool status = snapshot[i].GetValue<bool>("Status");
                    NewsCategory newsCategory = new NewsCategory
                    {
                        Id = id,
                        Name = name,
                        Status = status
                    };
                    if (newsCategoriesSql.Any(nc => nc.Id == newsCategory.Id))
                    {
                        await _newsCategoryRepository.UpdateNewsCategory(newsCategory);
                    }
                    else
                    {
                        await _newsCategoryRepository.CreateNewsCategory(newsCategory);
                    }
                }

                response.Data = true;
                response.Message = "Streaming de Dados de Categorias de Notícias Realizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<bool>> NewsSubcategoryDataStreaming()
        {
            ResponseModelDTO<bool> response = new ResponseModelDTO<bool>();
            try
            {
                var newsSubcategoriesSql = await _newsSubcategoryRepository.GetNewsSubcategories();

                var collection = _firestoreDb.Collection("NewsSubcategories");
                var snapshot = await collection.GetSnapshotAsync();
                for (int i = 0; i < snapshot.Count; i++)
                {
                    Guid id = Guid.Parse(snapshot[i].Id);
                    string name = snapshot[i].GetValue<string>("Name");
                    bool status = snapshot[i].GetValue<bool>("Status");
                    Guid categoryId = Guid.Parse(snapshot[i].GetValue<string>("CategoryId"));
                    NewsSubcategory newsSubcategory = new NewsSubcategory
                    {
                        Id = id,
                        Name = name,
                        Status = status,
                        CategoryId = categoryId
                    };
                    if (newsSubcategoriesSql.Any(nc => nc.Id == newsSubcategory.Id))
                    {
                        await _newsSubcategoryRepository.UpdateNewsSubcategory(newsSubcategory);
                    }
                    else
                    {
                        await _newsSubcategoryRepository.CreateNewsSubcategory(newsSubcategory);
                    }
                }

                response.Data = true;
                response.Message = "Streaming de Dados de Subcategorias de Notícias Realizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<bool>> NewsDataStreaming()
        {
            ResponseModelDTO<bool> response = new ResponseModelDTO<bool>();
            try
            {
                var newsSql = await _newsRepository.GetNews();

                var collection = _firestoreDb.Collection("News");
                var snapshot = await collection.GetSnapshotAsync();
                var subcategoriesSql = await _newsSubcategoryRepository.GetNewsSubcategories();
                for (int i = 0; i < snapshot.Count; i++)
                {
                    Guid id = Guid.Parse(snapshot[i].Id);
                    NewsStatusDTO status = (NewsStatusDTO)snapshot[i].GetValue<int>("Status");
                    string newsUrl = snapshot[i].GetValue<string>("NewsUrl");
                    string title = snapshot[i].GetValue<string>("Title");
                    string subtitle = snapshot[i].GetValue<string>("Subtitle");
                    string newsBody = snapshot[i].GetValue<string>("NewsBody");
                    string imgUrl = snapshot[i].GetValue<string>("ImageUrl");
                    DateTime publishDate = snapshot[i].GetValue<DateTime>("PublishDate");
                    Guid authorId = Guid.Parse(snapshot[i].GetValue<string>("AuthorId"));
                    Guid editorId = Guid.Parse(snapshot[i].GetValue<string>("EditorId"));
                    Guid categoryId = Guid.Parse(snapshot[i].GetValue<string>("CategoryId"));
                    string[] subcategoriesArray = snapshot[i].GetValue<string[]>("Subcategories");
                    UpdateNewsDTO news = new UpdateNewsDTO
                    {
                        Id = id,
                        Status = status,
                        NewsUrl = newsUrl,
                        Title = title,
                        Subtitle = subtitle,
                        NewsBody = newsBody,
                        ImageUrl = imgUrl,
                        PublishDate = publishDate,
                        AuthorId = authorId,
                        EditorId = editorId,
                        CategoryId = categoryId,
                        Subcategories = new List<NewsSubcategory>()
                    };
                    foreach (var subcategory in subcategoriesArray)
                    {
                        var newsSubcategory = subcategoriesSql.FirstOrDefault(sc => sc.Id == Guid.Parse(subcategory));
                        news.Subcategories.Add(newsSubcategory);
                    }
                    if (newsSql.Any(u => u.Id == news.Id))
                    {
                        var newsMapped = _mapper.Map<News>(news);
                        await _newsRepository.UpdateNews(newsMapped);
                    }
                    else
                    {
                        var newsMapped = _mapper.Map<News>(news);
                        await _newsRepository.CreateNews(newsMapped);
                    }
                }

                response.Data = true;
                response.Message = "Streaming de Dados de Notícias Realizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<bool>> ReaderUserDataStreaming()
        {
            ResponseModelDTO<bool> response = new ResponseModelDTO<bool>();
            try
            {
                var readerUsersSql = await _readerUserRepository.GetReaderUsers();

                var collection = _firestoreDb.Collection("ReaderUsers");
                var snapshot = await collection.GetSnapshotAsync();
                for (int i = 0; i < snapshot.Count; i++)
                {
                    Guid id = Guid.Parse(snapshot[i].Id);
                    UserRole userRole = (UserRole)snapshot[i].GetValue<int>("Role");
                    string completeName = snapshot[i].GetValue<string>("CompleteName");
                    string email = snapshot[i].GetValue<string>("Email");
                    string password = snapshot[i].GetValue<string>("Password");
                    bool status = snapshot[i].GetValue<bool>("Status");
                    ReaderUser readerUser = new ReaderUser
                    {
                        Id = id,
                        Role = userRole,
                        CompleteName = completeName,
                        Email = email,
                        Password = password,
                        Status = status
                    };
                    if (readerUsersSql.Any(u => u.Id == readerUser.Id))
                    {
                        await _readerUserRepository.UpdateReaderUser(readerUser);
                    }
                    else
                    {
                        await _readerUserRepository.CreateReaderUser(readerUser);
                    }
                }

                response.Data = true;
                response.Message = "Streaming de Dados de Usuários Leitores Realizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<bool>> ProfessionalInformationDataStreaming()
        {
            ResponseModelDTO<bool> response = new ResponseModelDTO<bool>();
            try
            {
                var professionalInformationsSql = await _professionalInformationRepository.GetProfessionalInformations();

                var collection = _firestoreDb.Collection("ProfessionalInformations");
                var snapshot = await collection.GetSnapshotAsync();
                for (int i = 0; i < snapshot.Count; i++)
                {
                    Guid id = Guid.Parse(snapshot[i].Id);
                    string completeName = snapshot[i].GetValue<string>("CompleteName");
                    string email = snapshot[i].GetValue<string>("Email");
                    string completeAddress = snapshot[i].GetValue<string>("CompleteAddress");
                    string objective = snapshot[i].GetValue<string>("Objective");
                    string imgUrl = snapshot[i].GetValue<string>("ImageUrl");
                    string workPlatform = snapshot[i].GetValue<string>("WorkPlatform");
                    bool status = snapshot[i].GetValue<bool>("Status");
                    Guid userId = Guid.Parse(snapshot[i].GetValue<string>("UserId"));
                    ProfessionalInformation professionalInformation = new ProfessionalInformation
                    {
                        Id = id,
                        CompleteName = completeName,
                        Email = email,
                        CompleteAddress = completeAddress,
                        Objective = objective,
                        ImgUrl = imgUrl,
                        WorkPlatformUrl = workPlatform,
                        Status = status,
                        UserId = userId
                    };
                    if (professionalInformationsSql.Any(pi => pi.Id == professionalInformation.Id))
                    {
                        await _professionalInformationRepository.UpdateProfessionalInformation(professionalInformation);
                    }
                    else
                    {
                        await _professionalInformationRepository.CreateProfessionalInformation(professionalInformation);
                    }
                }

                response.Data = true;
                response.Message = "Streaming de Dados de Informações Profissionais Realizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<bool>> ProfessionalSkillNewsDataStreaming()
        {
            ResponseModelDTO<bool> response = new ResponseModelDTO<bool>();
            try
            {
                var professionalSkillsSql = await _professionalSkillRepository.GetProfessionalSkills();

                var collection = _firestoreDb.Collection("ProfessionalSkills");
                var snapshot = await collection.GetSnapshotAsync();
                for (int i = 0; i < snapshot.Count; i++)
                {
                    Guid id = Guid.Parse(snapshot[i].Id);
                    string skill1 = snapshot[i].GetValue<string>("Skill1");
                    string skill2 = snapshot[i].GetValue<string>("Skill2");
                    string skill3 = snapshot[i].GetValue<string>("Skill3");
                    string skill4 = snapshot[i].GetValue<string>("Skill4");
                    bool status = snapshot[i].GetValue<bool>("Status");
                    Guid userId = Guid.Parse(snapshot[i].GetValue<string>("UserId"));
                    ProfessionalSkill professionalSkill = new ProfessionalSkill
                    {
                        Id = id,
                        Skill1 = skill1,
                        Skill2 = skill2,
                        Skill3 = skill3,
                        Skill4 = skill4,
                        Status = status,
                        UserId = userId
                    };
                    if (professionalSkillsSql.Any(pi => pi.Id == professionalSkill.Id))
                    {
                        await _professionalSkillRepository.UpdateProfessionalSkill(professionalSkill);
                    }
                    else
                    {
                        await _professionalSkillRepository.CreateProfessionalSkill(professionalSkill);
                    }
                }

                response.Data = true;
                response.Message = "Streaming de Dados de Habilidades Profissionais Realizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModelDTO<bool>> FormationNewsDataStreaming()
        {
            ResponseModelDTO<bool> response = new ResponseModelDTO<bool>();
            try
            {
                var formationsSql = await _formationRepository.GetFormations();

                var collection = _firestoreDb.Collection("Formations");
                var snapshot = await collection.GetSnapshotAsync();
                for (int i = 0; i < snapshot.Count; i++)
                {
                    Guid id = Guid.Parse(snapshot[i].Id);
                    string name = snapshot[i].GetValue<string>("Name");
                    string institution = snapshot[i].GetValue<string>("Institution");
                    DateTime startDate = snapshot[i].GetValue<DateTime>("StartDate");
                    DateTime endDate = snapshot[i].GetValue<DateTime>("EndDate");
                    string activity1 = snapshot[i].GetValue<string>("Activity1");
                    string activity2 = snapshot[i].GetValue<string>("Activity2");
                    string activity3 = snapshot[i].GetValue<string>("Activity3");
                    bool status = snapshot[i].GetValue<bool>("Status");
                    Guid userId = Guid.Parse(snapshot[i].GetValue<string>("UserId"));
                    Formation formation = new Formation
                    {
                        Id = id,
                        Name = name,
                        Institution = institution,
                        StartDate = startDate,
                        EndDate = endDate,
                        Activity1 = activity1,
                        Activity2 = activity2,
                        Activity3 = activity3,
                        Status = status,
                        UserId = userId
                    };
                    if (formationsSql.Any(pi => pi.Id == formation.Id))
                    {
                        await _formationRepository.UpdateFormation(formation);
                    }
                    else
                    {
                        await _formationRepository.CreateFormation(formation);
                    }
                }

                response.Data = true;
                response.Message = "Streaming de Dados de Formações Realizado com Sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
