# Create date : 2019.02.19 (Eunsu)

# graphics : NVIDIA GeForce RTX 2080 SUPER

# OS
# windows10 pro

# Anaconda 2019.10 for windows (Python 3.7 version) 64bit
# https://repo.anaconda.com/archive/Anaconda3-2019.10-Windows-x86_64.exe


# anaconda prompt 관리자 권한으로 실행

#####################################
# conda create -n [name] python=3.6 #
#####################################

import os

os.system('python -m pip install --upgrade pip')

os.system('conda install -y tensorflow-gpu==1.12')
os.system('conda install -y scipy')
os.system('conda install -y keras')
os.system('conda install -y pandas')
os.system('conda install -y matplotlib')
os.system('conda install -y scikit-learn')
os.system('conda install -y pillow')
os.system('conda install -y jupyter')

os.system('conda install -yc anaconda numpy')
os.system('conda install -yc anaconda msgpack-python')
os.system('conda install -yc anaconda tornado')

os.system('conda install -yc conda-forge opencv')
os.system('conda install -yc conda-forge tqdm')
os.system('conda install -yc conda-forge/label/gcc7 tqdm')
os.system('conda install -yc conda-forge/label/cf201901 tqdm')

os.system('pip install keras_tqdm')

os.system('conda install -c conda-forge nodejs')
os.system('conda install -c conda-forge/label/gcc7 nodejs')
os.system('conda install -c conda-forge/label/cf201901 nodejs')
os.system('conda install -c conda-forge/label/cf202003 nodejs')
