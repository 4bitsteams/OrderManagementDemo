using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Model.Extention
{
    public class DefaultPageViewModel<TCreate, TEdit, TDetail, TSearchOption, TSearchResult> where TCreate : class where TEdit : class where TSearchOption : class where TSearchResult : class
    {
        public DefaultPageViewModel()
        {
        }
        public TCreate CreateViewModel { get; set; }
        public TEdit EditViewModel { get; set; }
        public TDetail DetailViewModel { get; set; }
        public TSearchOption SearchOptionViewModel { get; set; }
        public TSearchResult SearchResultViewModel { get; set; }

        public DefaultPageViewModel(TCreate createViewModel, TEdit editViewModel, TDetail detailViewModel, TSearchOption searchOptionViewModel, TSearchResult searchResultViewModel)
        {
            CreateViewModel = createViewModel;
            EditViewModel = editViewModel;
            DetailViewModel = detailViewModel;
            SearchOptionViewModel = searchOptionViewModel;
            SearchResultViewModel = searchResultViewModel;
        }
        public ControllerBase ControllerBase { get; set; }
    }

    public class DefaultPageViewModel<TCreate, TEdit, TSearchOption, TSearchResult> where TCreate : class where TEdit : class where TSearchOption : class where TSearchResult : class
    {
        public DefaultPageViewModel()
        {
        }
        public TCreate CreateViewModel { get; set; }
        public TEdit EditViewModel { get; set; }
        public TSearchOption SearchOptionViewModel { get; set; }
        public TSearchResult SearchResultViewModel { get; set; }

        public DefaultPageViewModel(TCreate createViewModel, TEdit editViewModel, TSearchOption searchOptionViewModel, TSearchResult searchResultViewModel)
        {
            CreateViewModel = createViewModel;
            EditViewModel = editViewModel;
            SearchOptionViewModel = searchOptionViewModel;
            SearchResultViewModel = searchResultViewModel;
        }
        public ControllerBase ControllerBase { get; set; }
    }
    public class DefaultPageViewModel<TCreateOrEdit, TSearchOption, TSearchResult> : DefaultPageViewModelBase where TCreateOrEdit : class where TSearchOption : class where TSearchResult : class
    {

        public TCreateOrEdit CreateorEditViewModel { get; set; }
        public TSearchOption SearchOptionViewModel { get; set; }
        public TSearchResult SearchResultViewModel { get; set; }


        public DefaultPageViewModel()
        {
        }

        public DefaultPageViewModel(TCreateOrEdit createorEditViewModel, TSearchOption searchOptionViewModel, TSearchResult searchResultViewModel)
        {
            CreateorEditViewModel = createorEditViewModel;
            SearchOptionViewModel = searchOptionViewModel;
            SearchResultViewModel = searchResultViewModel;
        }
        public ControllerBase ControllerBase { get; set; }
    }

    public class DefaultPageViewModel<TSearchOption, TSearchResult> : DefaultPageViewModelBase where TSearchOption : class where TSearchResult : class
    {
        public DefaultPageViewModel()
        {
            //
        }

        public TSearchOption SearchOptionViewModel { get; set; }
        public TSearchResult SearchResultViewModel { get; set; }

        public DefaultPageViewModel(TSearchOption searchOptionViewModel, TSearchResult searchResultViewModel)
        {
            SearchOptionViewModel = searchOptionViewModel;
            SearchResultViewModel = searchResultViewModel;
        }
        public ControllerBase ControllerBase { get; set; }

    }

    public class DefaultPageViewModelBase
    {
        public int CountryId { get; set; }

        public int ProgrammeGroupId { get; set; }

        public int ProgrammeId { get; set; }

        public int SubProgrammeId { get; set; }

        public int ProjectId { get; set; }

        public int ReportTypeId { get; set; }

        public int AuditTypeId { get; set; }

        public int RiskTypeId { get; set; }

        public int AnnualAuditPlanYear { get; set; }

        public int AnnualAuditPlanId { get; set; }
        public int ZoneId { get; set; }

        public int AuditPlanStatusId { get; set; }

        public string AuditPlanStatusName { get; set; }

        public int AuditPlanStageId { get; set; }

        public string RequestedUrl { get; set; }

        public string UserId { get; set; }

        public string ComponentKey { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
