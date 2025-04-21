using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using WpfMVVM.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using WpfMVVM.Models.MetaData;

namespace WpfMVVM.Models
{
    [MetadataType(typeof(InventoryMetaData))]
    public partial class Inventory : EntityBase, IDataErrorInfo
    {
        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";
        public override string ToString()
        {
            return $"{this.PetName ?? "NONAME"} is a {this.Color} " +
                $"{this.Make} with ID {this.Id}";
        }
        private int _carId;
        private string _make;
        private string _color;
        private string _petName;
        private bool _isChanged = false;
        private string _error;

        public override event PropertyChangedEventHandler PropertyChanged;
        public string this[string columnName]
        {
            get
            {
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(Id):
                        AddErrors(nameof(Id), GetErrorsFromAnnotations(nameof(Id), Id));
                        break;
                    case nameof(Make):
                        hasError = CheckMakeAndColor();
                        if (Make == "ModelT")
                        {
                            AddError(nameof(Make), "Too Old");
                            hasError = true;
                        }
                        if (!hasError)
                        {
                            ClearErrors(nameof(Make));
                            ClearErrors(nameof(Color));
                        }
                        AddErrors(nameof(Make), GetErrorsFromAnnotations(nameof(Make), Make));
                        break;
                    case nameof(Color):
                        hasError = CheckMakeAndColor();
                        if (!hasError)
                        {
                            ClearErrors(nameof(Make));
                            ClearErrors(nameof(Color));
                        }
                        AddErrors(nameof(Color), GetErrorsFromAnnotations(nameof(Color), Color));
                        break;
                    case nameof(PetName):
                        AddErrors(nameof(PetName), GetErrorsFromAnnotations(nameof(PetName), PetName));
                        break;
                }
                return string.Empty;
            }
        }
        [NotMapped]
        public string Error { get => _error; set { } }

        
        [Required]
        [StringLength(50)]
        public string Make
        {
            get => _make;
            set
            {
                if (value == _make) return;
                _make = value;
                OnPropertyChanged();
            }
        }
        [Required]
        [StringLength(50)]
        public string Color
        {
            get => _color;
            set
            {
                if (value == _color) return;
                _color = value;
                OnPropertyChanged();
            }
        }
        [StringLength(50)]
        public string PetName
        {
            get => _petName;
            set
            {
                if (value == _petName) return;
                _petName = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged))
            {
                IsChanged = true;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
        internal bool CheckMakeAndColor()
        {
            if (Make == "Chevy" && Color == "Pink")
            {
                AddError(nameof(Color), $"{Make}'s don't come in {Color}");
                AddError(nameof(Make), $"{Make}'s don't come in {Color}");
                return true;
            }
            return false;
        }
    }
}
